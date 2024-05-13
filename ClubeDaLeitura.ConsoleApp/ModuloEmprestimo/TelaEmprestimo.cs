using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class TelaEmprestimo : TelaBase
    {
        public TelaAmigo telaAmigo = null;
        public TelaRevista telaRevista = null;
        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;

        public override void ExecutarOperacoesEspecificas(char operacaoEscolhida)
        {
            if (operacaoEscolhida == '3')
                VisualizarEmprestimosMensais();

            if (operacaoEscolhida == '4')
                VisualizarEmprestimosEmAberto();

            if (operacaoEscolhida == '5')
                Devolucao();
        }

        public override char ApresentarSubMenu()
        {
            ApresentarCabecalho();

            Console.WriteLine("1 - Cadastrar empréstimo");
            Console.WriteLine("2 - Visualizar empréstimos cadastrados");
            Console.WriteLine("3 - Visualizar empréstimos mensais");
            Console.WriteLine("4 - Visualizar empréstimos em aberto");
            Console.WriteLine("5 - Devolução");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public override EntidadeBase ObterCadastro()
        {
            telaAmigo.VisualizarCadastros(false);

            Console.Write("Digite o id do amigo que está emprestando a revista: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            telaRevista.VisualizarCadastros(false);

            Console.Write("Digite o id da revista emprestada: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Amigo amigoEmprestimo = (Amigo)repositorioAmigo.SelecionarPeloId(idAmigo);
            Revista revistaEmprestimo = (Revista)repositorioRevista.SelecionarPeloId(idRevista);

            Emprestimo emprestimo = new Emprestimo(amigoEmprestimo, revistaEmprestimo);

            return emprestimo;
        }
        public override void VisualizarCadastros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando empréstimos cadastrados...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                "Id",
                "Amigo",
                "Revista",
                "Data de Empréstimo",
                "Data de Devolução",
                "Concluído"
                );

            List<EntidadeBase> emprestimosCadastrados = repositorio.SelecionarTodos();

            foreach (var emprestimo in emprestimosCadastrados)
            {
                Emprestimo e = (Emprestimo)emprestimo;

                Console.WriteLine(
                    "{0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, -20} | {5, -20}",
                    e.Id,
                    e.Amigo.Nome,
                    e.Revista.Titulo,
                    e.DataEmprestimo.ToShortDateString(),
                    e.DataDevolucao.ToShortDateString(),
                    e.Concluido ? "Sim" : "Não"
                    );
            }

            Console.ReadLine();
        }

        public void VisualizarEmprestimosMensais()
        {
            Console.Write("Digite o número do mês desejado para visualização: ");
            bool converteu = Int32.TryParse(Console.ReadLine(), out int mes);

            if (!converteu)
                ExibirMensagem("Valor digitado é inválido. Tente novamente!", ConsoleColor.Red);
            
            else
            {
                Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3, -10}",
                "Id", 
                "Amigo", 
                "Revista", 
                "Data de Emprestimo"
                );

                foreach (var emprestimo in repositorio.cadastros)
                {
                    Emprestimo e = (Emprestimo)emprestimo;

                    if (e.DataEmprestimo.Month == mes)
                    {
                        Console.WriteLine(
                        "{0, -10} | {1, -20} | {2, -10} | {3, -10}",
                        e.Id, 
                        e.Amigo.Nome, 
                        e.Revista.Titulo, 
                        e.DataEmprestimo.ToShortDateString()
                        );
                    }
                }
            }

            Console.ReadLine();
        }

        public void VisualizarEmprestimosEmAberto()
        {
            Console.WriteLine(
               "{0, -10} | {1, -15} | {2, -40} | {3, -10} | {4, -10}",
               "Id", 
               "Amigo", 
               "Revista", 
               "Data de Emprestimo", 
               "Data de Devolução"
               );

            foreach (var emprestimo in repositorio.cadastros)
            {
                Emprestimo e = (Emprestimo)emprestimo;

                if (!e.Concluido)
                {
                    Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -40} | {3, -10} | {4, -10}",
                    e.Id, 
                    e.Amigo.Nome, 
                    e.Revista.Titulo, 
                    e.DataEmprestimo.ToShortDateString(), 
                    e.DataDevolucao.ToShortDateString()
                    );
                }
            }

            Console.ReadLine();
        }

        public void Devolucao()
        {
            VisualizarEmprestimosEmAberto();
            Console.Write("Qual o id do empréstimo? ");
            int idEmprestimo = Convert.ToInt32(Console.ReadLine());

            Emprestimo emprestimo = (Emprestimo)repositorio.SelecionarPeloId(idEmprestimo);
            emprestimo.Concluido = true;

            if (emprestimo.DataDevolucao < DateTime.Now)
            {
                ExibirMensagem("Esta devolução está atrasada e gerou uma multa", ConsoleColor.Red);
                telaAmigo.RegistrarMulta(emprestimo.Amigo);
            }
            else
                ExibirMensagem("Devolução realizada com sucesso!", ConsoleColor.Green);

            Console.ReadLine();
        }

        public override void CadastrarEntidadeTeste()
        {
            Emprestimo emprestimo = new Emprestimo((Amigo)repositorioAmigo.SelecionarPeloId(1), (Revista)repositorioRevista.SelecionarPeloId(1));
            emprestimo.DataEmprestimo = new DateTime(2024,05,05);
            emprestimo.DataDevolucao = new DateTime(2024,05,08);

            repositorio.Cadastrar(emprestimo);
        }
    }
}
