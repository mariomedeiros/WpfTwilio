using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WpfTwilio
{
    interface IContatosData
    {
        void Guardar(List<Contato> contatos);
        List<Contato> Ler();
    }
}
