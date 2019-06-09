using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WpfTwilio.Model
{
    /// <summary>
    /// Contem os dados de uma mensagem enviada
    /// </summary>
    public class Mensagem
    {
        /// <summary>
        /// Faz o Set ou Get do Nome do Contato a enviar a mensagem
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Numero do Contato a enviar a mensagem
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Texto a enviar
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Sid desta mensgem no Twilio 
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Status desta mensgem no Twilio 
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Retorna a representação da Mensagem em string
        /// </summary>
        override public string ToString()
        {
            return String.Format("Nome: {0}, Numero: {1}, Texto: {2}, Estado: {3}", Nome, Numero, Texto, Status);
        }
    }
}


