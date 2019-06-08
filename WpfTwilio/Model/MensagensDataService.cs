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
            Msgs.Add(new Mensagem
            {
                Nome = Msg.Nome,
                Texto = Msg.Texto,
                Numero = Msg.Numero,
                Sid = Msg.Sid,
                Status = Msg.Status
            }
            );


            /*return (from cont in Msgs
                    where cont.Numero.Contains(to)
                    select cont).ToList();*/
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
            /*return (from cont in Msgs
                    where cont.Numero.Contains(to)
                    select cont).ToList();*/
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

        #region Sample Data 

        //public static List<Mensagem> Msgs;
        static List<Mensagem> Msgs = new List<Mensagem> { };
        /*
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

        };*/
        #endregion
    }
}
