using System;
using System.Collections.Generic;
using WpfTwilio.Model;
using System.Windows;
using System.Windows.Controls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WpfTwilio.Controller
{
    /// <summary>
    /// Controller para fornecer a lista de Mensagens enviadas e o seu estado
    /// </summary>
    public class MensagensController : BaseController
    {
        private IList<Model.Mensagem> mensagens;
       
        
        /// <summary>
        /// Obtem uma lista de Mensagens para que seja usado pela View
        /// </summary>
        public IList<Model.Mensagem> Mensagens
        {
            get { return mensagens; }
            private set
            {
                mensagens = value;
                //Notificar que a lista de mensagens foi atualizada
                OnPropertyChanged("Mensagens");
            }
        }


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

            //Register quando o ListView é selecionada para depois colocar pedir o estado dessa mensagem ao Twilio
            EventManager.RegisterClassHandler(typeof(Control), ListView.SelectionChangedEvent,
                         (SelectionChangedEventHandler)SelectionChanged);

            //Obter toda a lista de contatos por defeito
            GetAllMensagens();
        }


        /// <summary>
        /// Event handler para quando é selecionado uma mensagem
        /// </summary>
        void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //quando uma mensagem é selecionada, despoletar obter o estado da mensagem
            if (((Control)sender).Name == "ListViewMensagens")
            {
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                    Mediator.NotifyColleagues(Messages.GetEstadoMensagem, e.AddedItems[0]);
            }
        }


        /// <summary>
        /// Receber Notificação do mediador
        /// </summary>
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
        /// Adicionar nova mensagem
        /// </summary>
        public void AddMensagem(Mensagem to)
        {
            MensagensDataService.Add(to);
            GetAllMensagens();
        }


        /// <summary>
        /// Pedir estado da mensagem ao serviço twilio (sent, queued, etc)
        /// </summary>
        public void GetEstadoMensagem(Mensagem m)
        {
            LogInfo("Obter estado da mensagem... sid: " + m.Sid);

            try
            {
                //Inicializar detalhes da conta no Twilio
                TwilioClient.Init(
                    Properties.Settings.Default.TwilioAccountSid,
                    Properties.Settings.Default.TwilioAuthToken
                );

                //Chamar recurso no twilio para obter o estado da mensagem completa
                var messageResp = MessageResource.Fetch(m.Sid);               

                //actualizar a mensagem no modelo de dados
                MensagensDataService.SetStatus(m.Sid, messageResp.Status.ToString());

                LogInfo("Estado = " + messageResp.Status.ToString() + " sid: " + m.Sid);
            }
            catch (Exception ex)
            {
                LogErro("Erro ao tentar obter o estado da mensagem! " + ex.Message);                
            }
            
            //actualizar dados do controlador
            GetAllMensagens();
        }


        /// <summary>
        /// Obter todas as mensagens
        /// </summary>
        public void GetAllMensagens()
        {
            Mensagens = MensagensDataService.GetAllMensagens();
        }
    }
}

