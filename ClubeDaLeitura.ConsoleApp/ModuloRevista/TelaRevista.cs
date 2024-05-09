using ClubeDaLeitura.ConsoleApp.Compartilhado;
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
        RepositorioCaixa repositorioCaixa = null;

        public override EntidadeBase ObterCadastro()
        {
            Console.Write("Digite o título da revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o número da edição da revista: ");
            int edicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano da revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o id da caixa que contém a revista: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = (Caixa)repositorioCaixa.SelecionarPeloId(idCaixa);

            Revista revista = new Revista(titulo, edicao, ano, caixa);

            return revista;
        }
        public void CadastrarEntidadeTeste()
        {
            Revista revista = new Revista("Super Interessante", 2, 2011);

            repositorio.Cadastrar(revista);
        }
    }
}

