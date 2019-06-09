using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfTwilio.Model
{
    /// <summary>
    /// Contem os dados de uma entrada de log
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Faz o Set ou Get da Data/Hora
        /// </summary>
        public DateTime DataHora { get; set; }

        /// <summary>
        /// Faz o Set ou Get da mensagem de log
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// Retorna a representação do log em string
        /// </summary>
        override public string ToString()
        {
            return String.Format("{0}: {1}", DataHora, Msg);
        }
    }
}


