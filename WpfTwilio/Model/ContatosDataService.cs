using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfTwilio.Model
{
    /// <summary>
    /// Data service para fornecer os dados
    /// </summary>
    public class ContatosDataService
    {
        /// <summary>
        /// Obtem a lista completa de Contatos
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public static IList<Contato> GetAllContatos()
        {
            return sampleData.ToList();
        }


        static List<Contato> sampleData = new List<Contato>
        {
            new Contato
            {
                Nome = "Mario Medeiros",
                Numero = "+351962986010"
            },

            new Contato
            {
                Nome = "Isac Medeiros",
                Numero = "+351962986010"
            },

            new Contato
            {
                Nome = "Rui Almeida",
                Numero = "+351962986010"
            },

            new Contato
            {
                Nome = "Anfonso Duarte",
                Numero = "+351962986010"
            },

            new Contato
            {
                Nome = "Quaresma Santos",
                Numero = "+351962986010"
            },

            new Contato
            {
                Nome = "Cristiano Ronaldo",
                Numero = "+351962986010"
            }

        };

    }
}
