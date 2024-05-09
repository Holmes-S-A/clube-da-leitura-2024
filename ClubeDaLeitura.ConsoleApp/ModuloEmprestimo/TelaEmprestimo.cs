using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        RepositorioAmigo repositorioAmigo = null;
        RepositorioRevista repositorioRevista = null;

        public override EntidadeBase ObterCadastro()
        {
            Console.Write("Digite o id do amigo que está emprestando a revista: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o id da revista emprestada: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Amigo amigoEmprestimo = (Amigo)repositorioAmigo.SelecionarPeloId(idAmigo);
            Revista revistaEmprestimo = (Revista)repositorioRevista.SelecionarPeloId(idRevista);

            Emprestimo emprestimo = new Emprestimo(amigoEmprestimo, revistaEmprestimo);

            return emprestimo;
        }
    }
}
