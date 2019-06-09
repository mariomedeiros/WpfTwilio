using System;
using System.Windows.Input;
using System.Windows.Controls;
using WpfTwilio.Model;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WpfTwilio.Controller
{
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
            CommandManager.RegisterClassCommandBinding(typeof(Control),
                new CommandBinding(Commands.EnviarMensagem, ExecuteEnviarMensagem, CanExecuteEnviarMensagem));
            
            Mediator.Register(this, new[]
            {
                Messages.SelectContato
            });

            //////////////////////////////////////
        }

        //can execute handler for the CanExecuteEnviarMensagem command
        void CanExecuteEnviarMensagem(object sender, CanExecuteRoutedEventArgs e)
        {
            if (e.Parameter == null)
                e.CanExecute = false;
            else
                e.CanExecute = !String.IsNullOrEmpty(e.Parameter.ToString());
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

        /// <summary>
        /// Enviar mensagem para o serviço Twilio
        /// </summary>
        void ExecuteEnviarMensagem(object sender, ExecutedRoutedEventArgs e)
        {
           
            string msg = e.Parameter.ToString();

            Console.WriteLine("Texto: " + msg);

            if (!Validado(msg))
            {
                LogErro("Dados invalidos!");
                System.Windows.MessageBox.Show("Preencha todos os campos antes de enviar a mensagem.");
                return;
            }

            LogInfo("Enviando Mensagem... '" + msg + "'");
            
            try
            {
                //Inicializar detalhes da conta no Twilio
                TwilioClient.Init(
                    Properties.Settings.Default.TwilioAccountSid, 
                    Properties.Settings.Default.TwilioAuthToken
                );

                //Chamar recurso no twilio para Criar a nova mensagem e enviar
                var message = MessageResource.Create(
                    body: msg,
                    from: new Twilio.Types.PhoneNumber(Properties.Settings.Default.TwilioSourceNumber),
                    to: new Twilio.Types.PhoneNumber("whatsapp:"+ currentContato.Numero)
                );

                LogInfo("Mensagem enviada com sucesso! sid: " + message.Sid);

                // adicionar nova mensagem à lista depois de enviada
                Mensagem m = new Mensagem
                {
                    Nome = currentContato.Nome,
                    Numero = currentContato.Numero,
                    Texto = msg,
                    Sid = message.Sid,
                    Status = message.Status.ToString()
                };

                Mediator.NotifyColleagues(Messages.AddMensagem, m);

                LogInfo("Mensagem adicionada à lista de mensagens! sid: " + message.Sid);

                CurrentContato = null;
            }
            catch (Exception ex)
            {
                LogErro("Envio da mensagem Falhou! " + ex.Message);
            }    
        }


        /// <summary>
        /// Receber Notificação do mediador
        /// </summary>
        public override void MessageNotification(string message, object args)
        {
            switch (message)
            {                
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
