using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTwilio.Model;

namespace WpfTwilio.Controller
{
    /// <summary>
    /// Logs
    /// </summary>
    public class LogController : BaseController
    {
        #region Properties

        private IList<Log> logsLista;
        /// <summary>
        /// Obtem uma lista de contatos para que seja usado pela View
        /// </summary>
        public IList<Log> LogsLista
        {
            get { return logsLista; }
            private set
            {
                logsLista = value;
                //Notificar que a lista de protudos foi atualizada
                OnPropertyChanged("LogsLista");
            }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public LogController()
        {
            //Registar a procura por nome e obeter todos os contatos
            Mediator.Register(this, new[]
                {
                    Messages.LogAdd
                });

            //Obter toda a lista de contatos por defeito
            GetAllLogs();
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
                case Messages.LogAdd:
                    Add(args.ToString());
                    break;
            }
        }

        /// <summary>
        /// Applicar a procura do contato por nome
        /// </summary>
        /// <param name="contatoName">O Nome do contato a procurar</param>
        public void Add(string msg)
        {
            LogsLista = LogDataService.Add(msg);
        }

        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        public void GetAllLogs()
        {
            LogsLista = LogDataService.GetAllLogs();
        }
    }
}
