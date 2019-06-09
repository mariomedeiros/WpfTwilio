using System;
using System.Collections.Generic;
using WpfTwilio.Model;
using System.Windows;
using System.Windows.Controls;

namespace WpfTwilio.Controller
{
    public class ContatosListaController : BaseController
    {
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


        /// <summary>
        /// Event handler para quando é selecionado um contato
        /// </summary>
        void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Quando o contato é selecionado, a mensagem do tipo SelectContato é enviada para as vistas que estão à escuta
            if (((Control)sender).Name == "ListViewContatos"){
                if (e.AddedItems != null && e.AddedItems.Count > 0)
                    Mediator.NotifyColleagues(Messages.SelectContato, e.AddedItems[0]);
            }
        }


        /// <summary>
        /// Receber Notificação do mediador
        /// </summary>
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
