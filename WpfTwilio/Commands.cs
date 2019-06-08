using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfTwilio
{
    /// <summary>
    /// Comandos defenidos na aplicação
    /// </summary>
    public static class Commands
    {
     
        /// <summary>
        /// O command para enviar uma mensagem.
        /// </summary>
        public static RoutedUICommand EnviarMensagem = new RoutedUICommand("Enviar Mensagem", "EnviarMensagem", typeof(Commands));  
    }
}

