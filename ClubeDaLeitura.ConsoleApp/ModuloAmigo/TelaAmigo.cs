using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo : TelaBase
    {
        public override EntidadeBase ObterCadastro()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável pelo amigo: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite o endereço: ");
            string endereco = Console.ReadLine();

            Amigo amigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

            return amigo;
        }

        public void CadastrarEntidadeTeste()
        {
            Amigo amigo = new Amigo("Pedro", "Lucas", "49999054687", "rua hercilio luz");

            repositorio.Cadastrar(amigo);
        }
    }
}
