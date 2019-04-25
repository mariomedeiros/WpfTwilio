using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace WpfTwilio
{
    /// <summary>
    /// Where all application commands are defined
    /// </summary>
    public static class Commands
    {
        #region SearchContatoByNome

        /// <summary>
        /// O command SearchContatoByNome vai procurar uma lista de contatos por nome command to search for a set of products by product name.
        /// </summary>
        public static RoutedUICommand SearchContatoByNome
            = new RoutedUICommand("Procurar Contato pelo nome", "SearchContatoByNome", typeof(Commands));

        #endregion

        #region GetAllContatos

        /// <summary>
        /// O command GetAllContatos obtem todos os contatos.
        /// </summary>
        public static RoutedUICommand GetAllContatos
            = new RoutedUICommand("Get all contatos", "GetAllContatos", typeof(Commands));

        #endregion


    }
}

