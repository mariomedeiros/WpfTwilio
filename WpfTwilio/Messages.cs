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
        /// Notificar que todos os produtos devem ser retornados
        /// </summary>
        public const string GetAllContatos = "getAll";

        /// <summary>
        /// Notificar que a procura deve ser feita pelo Nome
        /// </summary>
        public const string SearchByNome = "searchByNome";

        /// <summary>
        /// Mensagem para notificar que o contato foi selecionado
        /// </summary>
        public const string SelectContato = "selectContato";


        public const string LimparEnvio = "limparEnvio";

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

    }
}

