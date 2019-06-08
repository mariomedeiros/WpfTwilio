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

        /// <summary>
        /// Obtem uma lista de Contatos a partir do filtro Nome
        /// </summary>
        /// <param name="nome">O Nome do contato a procurar com</param>
        /// <returns>Retorna uma lista de contatos</returns>
        public static IList<Contato> GetContatosByNome(string nome)
        {
            return (from cont in sampleData
                    where cont.Nome.Contains(nome)
                    select cont).ToList();
        }

        #region Sample Data 
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
            }

        };
        #endregion
    }
}
