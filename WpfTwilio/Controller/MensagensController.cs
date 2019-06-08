using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using WpfTwilio.Model;
using System.Windows;
using System.Windows.Controls;

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
                    Messages.SearchByTo,
                    Messages.GetAllMensagens
                });

            //Obter toda a lista de contatos por defeito
            GetAllMensagens();
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
                case Messages.SearchByTo:
                    ApplySearchByTo(args.ToString());
                    break;

                case Messages.GetAllMensagens:
                    GetAllMensagens();
                    break;
            }
        }

        /// <summary>
        /// Applicar a procura do contato por nome
        /// </summary>
        /// <param name="contatoName">O Nome do contato a procurar</param>
        public void ApplySearchByTo(string to)
        {
            Mensagens = MensagensDataService.GetMensagensByTo(to);
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

