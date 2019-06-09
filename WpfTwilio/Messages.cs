using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfTwilio
{
    /// <summary>
    /// Define a lista das mensagens que os controladores usam para comunicar uns com os outros
    /// </summary>
    public static class Messages
    {
        /// <summary>
        /// Notificar que todos os contatos devem ser retornados
        /// </summary>
        public const string GetAllContatos = "getAllContatos";

        /// <summary>
        /// Mensagem para notificar que o contato foi selecionado
        /// </summary>
        public const string SelectContato = "selectContato";

        /// <summary>
        /// Mensagem para notificar para enviar uma mensagem
        /// </summary>
        public const string EnviarMensagem = "enviarMensagem";

        /// <summary>
        /// Mensagem para notificar para enviar uma mensagem
        /// </summary>
        public const string GetAllMensagens = "getAllMensagens";

        /// <summary>
        /// Mensagem para notificar para enviar uma mensagem
        /// </summary>
        public const string AddMensagem = "addMensagem";

        /// <summary>
        /// Mensagem para notificar para enviar uma mensagem
        /// </summary>
        public const string GetEstadoMensagem = "getEstadoMensagem";

        /// <summary>
        /// Mensagem para notificar para adicionar logs
        /// </summary>
        public const string LogAdd = "logAdd";
    }
}

