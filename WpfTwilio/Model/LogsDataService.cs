using System;
using System.Collections.Generic;
using System.Linq;

namespace WpfTwilio.Model
{
    class LogsDataService
    {
        static List<Log> logs = new List<Log> {};


        /// <summary>
        /// Obtem a lista completa de logs
        /// </summary>
        public static IList<Log> GetAllLogs()
        {
            return logs.ToList();
        }


        /// <summary>
        /// Adiciona uma entrada de log nova e retorna a nova lista
        /// </summary>
        public static IList<Log> Add(string msg)
        {
            logs.Add(new Log {
                    DataHora = DateTime.Now,
                    Msg = msg
                }
            );

            return GetAllLogs();
        }        
    }
}


