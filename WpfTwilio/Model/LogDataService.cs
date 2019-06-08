using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTwilio.Model
{
    class LogDataService
    {
        /// <summary>
        /// Obtem a lista completa de Contatos
        /// </summary>
        /// <returns>Retorna uma lista de logs</returns>
        public static IList<Log> GetAllLogs()
        {
            return logs.ToList();
        }

        /// <summary>
        /// Obtem uma lista de Contatos a partir do filtro Nome
        /// </summary>
        /// <param name="nome">O Nome do contato a procurar com</param>
        /// <returns>Retorna uma lista de contatos</returns>
        public static IList<Log> Add(string msg)
        {
            logs.Add(new Log
                {
                    DataHora = DateTime.Now,
                    Msg = msg
                }
            );

            return GetAllLogs();
        }

        static List<Log> logs = new List<Log> { };
    }
}


