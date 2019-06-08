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
        /// Lista em memória de todos as mensagens enviadas
        /// </summary>
        static List<Mensagem> Msgs = new List<Mensagem> { };

        /// <summary>
        /// Obtem a lista completa de Contatos
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public static IList<Mensagem> GetAllMensagens()
        {
            if (Msgs == null)
                return null;

            return Msgs.ToList();
        }

        /// <summary>
        /// Obtem uma lista de Contatos a partir do filtro Nome
        /// </summary>
        /// <param name="nome">O Nome do contato a procurar com</param>
        /// <returns>Retorna uma lista de contatos</returns>
        public static void Add(Mensagem Msg)
        {
            Msgs.Add(Msg);
        }

        public static Mensagem GetMensagemBySid(string sid)
        {
            foreach (var item in Msgs)
            {
                if (item.Sid == sid)
                {
                    return item;
                }
            }

            return null;
        }

        public static void SetStatus(string sid, string status)
        {
            foreach (var item in Msgs)
            {
                if (item.Sid == sid)
                {
                    item.Status = status;
                }
            }
        }

       
    }
}
