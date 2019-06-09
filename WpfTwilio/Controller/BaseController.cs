using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WpfTwilio.Controller
{
    /// <summary>
    /// Classe base para todos os controladores
    /// </summary>
    public abstract class BaseController : INotifyPropertyChanged, IColleague
    {       
        static Mediator mediatorInstance = new Mediator();
     

        /// <summary>
        /// Despoletar um evento quando uma propriedade muda
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        /// <summary>
        /// Despoletar um evento do tipo PropertyChanged quando uma propriedade muda
        /// </summary>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        
        /// <summary>
        /// Gets the mediator for this controller
        /// </summary>
        public Mediator Mediator { get; private set; }


        /// <summary>
        /// Receber Notificação do mediador base para ser re-escrita nos descendentes
        /// </summary>
        public abstract void MessageNotification(string message, object args);


        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseController()
        {            
            Mediator = mediatorInstance;
        }


        /// <summary>
        /// Rotina de log de Informação comum a todos os controladores descendentes
        /// </summary>
        public void LogInfo(string msg)
        {
            Mediator.NotifyColleagues(Messages.LogAdd, "[INFO] " + msg);
        }


        /// <summary>
        /// Rotina de log de Erro comum a todos os controladores descendentes
        /// </summary>
        public void LogErro(string msg)
        {
            Mediator.NotifyColleagues(Messages.LogAdd, "[ERRO] " + msg);
        }
    }
}

