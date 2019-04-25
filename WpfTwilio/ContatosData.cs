using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTwilio
{
    class ContatosData : IContatosData
    {
        List<Contato> Contatos;

        public void Guardar(List<Contato> contatos)
        {
            Contatos = contatos;

        }

        public List<Contato> Ler()
        {
            throw new NotImplementedException();
        }
    }
}
