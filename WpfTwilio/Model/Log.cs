using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfTwilio.Model
{
    /// <summary>
    /// Contem os dados de um contato
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Faz o Set ou Get do Nome do Contato
        /// </summary>
        public DateTime DataHora { get; set; }

        /// <summary>
        /// Faz o Set ou Get do Numero do Contato
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Retorna a representação do Contato em string
        /// </summary>
        override public string ToString()
        {
            return String.Format("{0}: {1}", DataHora, Msg);
        }
    }
}


