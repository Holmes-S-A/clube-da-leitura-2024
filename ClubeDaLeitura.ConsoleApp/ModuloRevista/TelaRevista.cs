using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
    {
        public override EntidadeBase ObterCadastro()
        {
            throw new NotImplementedException();
        }
        public void CadastrarEntidadeTeste()
        {
            Revista revista = new Revista("Super Interessante", 2, 2011);

            repositorio.Cadastrar(revista);
        }
    }
}

