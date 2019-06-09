using System.Collections.Generic;
using System.Linq;


namespace WpfTwilio.Model
{
    public class MensagensDataService
    {
        /// <summary>
        /// Lista em memória de todos as mensagens enviadas
        /// </summary>
        static List<Mensagem> Msgs = new List<Mensagem> {};


        /// <summary>
        /// Obtem a lista completa de mensagens
        /// </summary>        
        public static IList<Mensagem> GetAllMensagens()
        {
            if (Msgs == null)
                return null;

            return Msgs.ToList();
        }

        
        /// <summary>
        /// Adicona uma nova mensagem na lista depois de enviada
        /// </summary>
        public static void Add(Mensagem Msg)
        {
            Msgs.Add(Msg);
        }


        /// <summary>
        /// Actualiza o estado na mensagem baseado no sid
        /// </summary>
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
