using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace WpfTwilio.Model
{
    public class MensagensDataService
    {
        /// <summary>
        /// Obtem a lista completa de Contatos
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public static IList<Mensagem> GetAllMensagens()
        {
            return Msgs.ToList();
        }

        /// <summary>
        /// Obtem uma lista de Contatos a partir do filtro Nome
        /// </summary>
        /// <param name="nome">O Nome do contato a procurar com</param>
        /// <returns>Retorna uma lista de contatos</returns>
        public static IList<Mensagem> GetMensagensByTo(string to)
        {
            return (from cont in Msgs
                    where cont.Numero.Contains(to)
                    select cont).ToList();
        }

        #region Sample Data 

        //public static List<Mensagem> Msgs;

        static List<Mensagem> Msgs = new List<Mensagem>
        {
            new Mensagem
            {
                Nome = "Mario Medeiros",
                Numero = "+351962986010",
                Texto = "Mensagem de text 1"//,
                //TwilioMsg = MessageResource.Create(CreateMessageOptions)
            },

            new Mensagem
            {
                Nome = "Mario Medeiros",
                Numero = "+351962986010",
                Texto = "Mensagem de text 2"//,
                //TwilioMsg = MessageResource.Create(CreateMessageOptions)
            }

        };
        #endregion
    }
}
