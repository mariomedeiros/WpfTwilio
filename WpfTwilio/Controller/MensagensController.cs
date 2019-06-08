using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using WpfTwilio.Model;
using System.Windows;
using System.Windows.Controls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WpfTwilio.Controller
{
    /// <summary>
    /// Controller para fornecer a lista de contatos
    /// </summary>
    public class MensagensController : BaseController
    {
        #region Properties

        private IList<Model.Mensagem> mensagens;
        /// <summary>
        /// Obtem uma lista de contatos para que seja usado pela View
        /// </summary>
        public IList<Model.Mensagem> Mensagens
        {
            get { return mensagens; }
            private set
            {
                mensagens = value;
                //Notificar que a lista de protudos foi atualizada
                OnPropertyChanged("Mensagens");
            }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public MensagensController()
        {
            //Registar a procura por nome e obeter todos os contatos
            Mediator.Register(this, new[]
                {
                    Messages.AddMensagem,
                    Messages.GetAllMensagens,
                    Messages.GetEstadoMensagem
                });

            EventManager.RegisterClassHandler(typeof(Control), ListView.SelectionChangedEvent,
                         (SelectionChangedEventHandler)SelectionChanged);

            //Obter toda a lista de contatos por defeito
            GetAllMensagens();
        }

        void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Notify that the selected item has changed

            if (((Control)sender).Name == "ListViewMensagens")
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                    Mediator.NotifyColleagues(Messages.GetEstadoMensagem, e.AddedItems[0]);
            }
        }

        /// <summary>
        /// Notification from the Mediator
        /// </summary>
        /// <param name="message">The message type</param>
        /// <param name="args">Arguments for the message</param>
        public override void MessageNotification(string message, object args)
        {
            switch (message)
            {
                case Messages.AddMensagem:
                    AddMensagem((Mensagem)args);
                    break;

                case Messages.GetAllMensagens:
                    GetAllMensagens();
                    break;

                case Messages.GetEstadoMensagem:
                    GetEstadoMensagem((Mensagem)args);
                    break;
                    
            }
        }



        /// <summary>
        /// Applicar a procura do contato por nome
        /// </summary>
        /// <param name="contatoName">O Nome do contato a procurar</param>
        public void AddMensagem(Mensagem to)
        {
            MensagensDataService.Add(to);
            GetAllMensagens();
        }

        public void GetEstadoMensagem(Mensagem m)
        {
            //MensagensDataService.Add(to);
            LogInfo("Estado? sid: " + m.Sid);


            Console.WriteLine("GetEstadoMensagem: " + m.Texto);

            var mensagem = MensagensDataService.GetMensagemBySid(m.Sid);


            string outMessage = "Mensagem enviada com sucesso!";

            try
            {
                TwilioClient.Init(
                    Properties.Settings.Default.TwilioAccountSid,
                    Properties.Settings.Default.TwilioAuthToken
                );


                var messageResp = MessageResource.Fetch(m.Sid);

                Console.WriteLine("Status = " + messageResp.Status.ToString());

                MensagensDataService.SetStatus(m.Sid, messageResp.Status.ToString());

                LogInfo("Estado = " + messageResp.Status.ToString() + " sid: " + m.Sid);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                outMessage = "Error! \n\n" + ex.Message;
                LogErro("Error! " + ex.Message);
                //System.Windows.MessageBox.Show(outMessage);
            }
          
            GetAllMensagens();
        }

        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        public void GetAllMensagens()
        {
            Mensagens = MensagensDataService.GetAllMensagens();
        }
    }
}

