using System.Collections.Generic;
using WpfTwilio.Model;

namespace WpfTwilio.Controller
{
    public class LogController : BaseController
    {
        private IList<Log> logsLista;

        
        /// <summary>
        /// Obtem uma lista de logs para que seja usado pela View
        /// </summary>
        public IList<Log> LogsLista
        {
            get { return logsLista; }
            private set
            {
                logsLista = value;
                //Notificar que a lista de logs foi atualizada
                OnPropertyChanged("LogsLista");
            }
        }


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

            //Obter toda a lista de logs por defeito
            GetAllLogs();
        }


        /// <summary>
        /// Receber Notificação do mediador
        /// </summary>
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
        /// Applicar uma nova mensagem de log
        /// </summary>
        public void Add(string msg)
        {
            //Adicionar e atualizar os dados locais com os dados dos logs
            LogsLista = LogDataService.Add(msg);
        }


        /// <summary>
        /// Obter todos os logs
        /// </summary>
        public void GetAllLogs()
        {
            LogsLista = LogDataService.GetAllLogs();
        }
    }
}
