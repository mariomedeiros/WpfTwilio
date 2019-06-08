using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Controls;
using WpfTwilio.Model;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WpfTwilio.Controller
{
    
    /// <summary>
    /// Controller para enviar mensagens
    /// </summary>
    public class EnviarMensagemController: BaseController
    {
        Contato currentContato;

        public Contato CurrentContato
        {
            get { return currentContato; }
            set
            {
                currentContato = value;
                OnPropertyChanged("CurrentContato");
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public EnviarMensagemController()
        {
            //register the search product by name command
            CommandManager.RegisterClassCommandBinding(typeof(Control),
                new CommandBinding(Commands.EnviarMensagem, ExecuteEnviarMensagem, CanExecuteEnviarMensagem));
            
            //register to the mediator for the SelectProduct message
            Mediator.Register(this, new[]
            {
                Messages.SelectContato
            });

            //////////////////////////////////////
        }

        #region Command handlers
        //execute handler for the SearchProductByName command
        void ExecuteEnviarMensagem(object sender, ExecutedRoutedEventArgs e)
        {
            //notify other colleagues that the user wants to search by name. 
            //Also pass the name to search with, as parameter
            Mediator.NotifyColleagues(Messages.EnviarMensagem, e.Parameter.ToString());


            try
            {
                string msg = e.Parameter.ToString();

                Console.WriteLine(e.Parameter.ToString());


                //TwilioClient.Init(accountSid, authToken);

                TwilioClient.Init(Properties.Settings.Default.TwilioAccountSid, Properties.Settings.Default.TwilioAuthToken);


                var message = MessageResource.Create(
                    body: msg,
                    from: new Twilio.Types.PhoneNumber("whatsapp:+14155238886"),
                    to: new Twilio.Types.PhoneNumber("whatsapp:+351962986010")
                );

                Console.WriteLine(message.Sid);

                
                var messageResp = MessageResource.Fetch(message.Sid);

                Console.WriteLine(messageResp.Status.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }





            //throw new System.ArgumentException("Execute Enviar Mensagem", "original");
        }

        //can execute handler for the CanExecuteEnviarMensagem command
        void CanExecuteEnviarMensagem(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter == null)
                e.CanExecute = false;
            else
                e.CanExecute = !String.IsNullOrEmpty(
                    e.Parameter.ToString());
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
                //change the CurrentProduct to be the newly selected product
                case Messages.SelectContato:
                    CurrentContato = (Contato)args;
                    break;
            }
        }
    }
}
