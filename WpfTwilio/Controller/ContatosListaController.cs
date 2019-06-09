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
        /// Construtor
        /// </summary>
        public ContatosListaController()
        {
            //Registar a a lista de Mensages que este Controlador poderá processer
            Mediator.Register(this, new[]
                {
                    Messages.GetAllContatos
                });

            //Register quando o ListView é selecionada para depois colocar esses dados na view de enviar mensagens.
            EventManager.RegisterClassHandler(typeof(Control), ListView.SelectionChangedEvent, (SelectionChangedEventHandler)SelectionChanged);

            //Obter toda a lista de contatos por defeito
            GetAllContatos();
        }


        //event handler for the selection changed
        void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Quando o contato é selecionado, a mensagem do tipo SelectContato é enviada para as vistas que estão à escuta
            if (((Control)sender).Name == "ListViewContatos"){
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                    Mediator.NotifyColleagues(Messages.SelectContato, e.AddedItems[0]);
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

                case Messages.GetAllContatos:
                    GetAllContatos();
                    break;
            }
        }



        /// <summary>
        /// Obter todos os contatos
        /// </summary>
        public void GetAllContatos()
        {
            ContatosLista = ContatosDataService.GetAllContatos();
        }
    }
}
