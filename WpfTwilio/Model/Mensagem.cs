using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WpfTwilio.Model
{
    /// <summary>
    /// Contem os dados de um contato
    /// </summary>
    public class Mensagem
    {
        /// <summary>
        /// Faz o Set ou Get do Nome do Contato
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Numero do Contato
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Numero do Contato
        /// </summary>
        public string Texto { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Numero do Contato
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Numero do Contato
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Retorna a representação do Contato em string
        /// </summary>
        override public string ToString()
        {
            return String.Format("Nome: {0}, Numero: {1}, Texto: {2}, Estado: {3}", Nome, Numero, Texto, Status);
        }
    }
}


