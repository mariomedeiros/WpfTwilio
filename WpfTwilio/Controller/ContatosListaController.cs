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
    public class ContatosListaController : BaseController
    {
        #region Properties

        private IList<Model.Contato> contatosLista;
        /// <summary>
        /// Obtem uma lista de contatos para que seja usado pela View
        /// </summary>
        public IList<Model.Contato> ContatosLista
        {
            get { return contatosLista; }
            private set
            {
                contatosLista = value;
                //Notificar que a lista de protudos foi atualizada
                OnPropertyChanged("ContatosLista");
            }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public ContatosListaController()
        {
            //Registar a procura por nome e obeter todos os contatos
            Mediator.Register(this, new[]
                {
                    Messages.SearchByNome,
                    Messages.GetAllContatos
                });

            //Register to the SelectedIndex Routed event
            EventManager.RegisterClassHandler(typeof(Control), ListView.SelectionChangedEvent,
                (SelectionChangedEventHandler)SelectionChanged);

            //Obter toda a lista de contatos por defeito
            GetAllContatos();
        }

        #region Event Handler
        //event handler for the selection changed
        void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Notify that the selected item has changed
            if (e.AddedItems != null && e.AddedItems.Count > 0)
                Mediator.NotifyColleagues(Messages.SelectContato, e.AddedItems[0]);
        }
        #endregion

        /// <summary>
        /// Notification from the Mediator
        /// </summary>
        /// <param name="message">The message type</param>
        /// <param name="args">Arguments for the message</param>
        public override void MessageNotification(string message, object args)
        {
            switch (message)
            {
                case Messages.SearchByNome:
                    ApplySearchByNome(args.ToString());
                    break;

                case Messages.GetAllContatos:
                    GetAllContatos();
                    break;
            }
        }

        /// <summary>
        /// Applicar a procura do contato por nome
        /// </summary>
        /// <param name="contatoName">O Nome do contato a procurar</param>
        public void ApplySearchByNome(string contatoName)
        {
            ContatosLista = ContatosDataService.GetContatosByNome(contatoName);
        }

        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        public void GetAllContatos()
        {
            ContatosLista = ContatosDataService.GetAllContatos();
        }
    }
}
