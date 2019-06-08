using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfTwilio.Model
{
    /// <summary>
    /// Contem os dados de um contato
    /// </summary>
    public class Contato
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
        /// Retorna a representação do Contato em string
        /// </summary>
        override public string ToString() 
        {
            return String.Format("Nome: {0}, Numero: {1}", Nome, Numero);
        }
    }
}

