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
        Mensagem currentContato;

        public Mensagem CurrentContato
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
                Messages.SelectContato,
                Messages.LimparEnvio
            });

            //////////////////////////////////////
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

        private bool Validado(string msg)
        {
            if (currentContato == null)
                return false;
            if (String.IsNullOrEmpty(currentContato.Numero))
                return false;
            if (String.IsNullOrEmpty(currentContato.Nome))
                return false;
            if (String.IsNullOrEmpty(msg))
                return false;

            return true;
        }

        //execute handler for the SearchProductByName command
        void ExecuteEnviarMensagem(object sender, ExecutedRoutedEventArgs e)
        {
            Mediator.NotifyColleagues(Messages.LogAdd, "nova mensagem");


            string msg = e.Parameter.ToString();

            Console.WriteLine("Texto: " + msg);

            string outMessage = "";

            if (!Validado(msg))
            {
                System.Windows.MessageBox.Show("Preencha todos os campos antes de enviar a mensagem.");
                return;
            }




            try
            {                
                TwilioClient.Init(
                    Properties.Settings.Default.TwilioAccountSid, 
                    Properties.Settings.Default.TwilioAuthToken
                );

                var message = MessageResource.Create(
                    body: msg,
                    from: new Twilio.Types.PhoneNumber(Properties.Settings.Default.TwilioSourceNumber),
                    to: new Twilio.Types.PhoneNumber("whatsapp:"+ currentContato.Numero)
                );

                Console.WriteLine("Mensagem enviada: " + message.Sid);

                Mensagem m = new Mensagem
                {
                    Nome = currentContato.Nome,
                    Numero = currentContato.Numero,
                    Texto = msg,
                    Sid = message.Sid,
                    Status = message.Status.ToString()
                };

                Mediator.NotifyColleagues(Messages.AddMensagem, m);
                
                outMessage = "Mensagem enviada com sucesso!";

                CurrentContato = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                outMessage = "Error ao enviar mensagem! \n\n" + ex.Message;
            }

            System.Windows.MessageBox.Show(outMessage);          
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
                //change the CurrentProduct to be the newly selected product
                case Messages.SelectContato:
                    CurrentContato = new Mensagem
                    {
                        Nome = ((Contato)args).Nome,
                        Numero = ((Contato)args).Numero,
                        Texto = ""
                    };
                    break;
            }
        }
    }
}
