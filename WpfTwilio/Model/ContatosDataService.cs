using System.Collections.Generic;
using System.Linq;

namespace WpfTwilio.Model
{
    public class ContatosDataService
    {
        /// <summary>
        /// Obtem a lista completa de Contatos
        /// </summary>
        public static IList<Contato> GetAllContatos()
        {
            return contatos.ToList();
        }


        /// <summary>
        /// Carregar uma lista fixa com todos os contatos pré carregados
        /// </summary>
        static List<Contato> contatos = new List<Contato>
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
