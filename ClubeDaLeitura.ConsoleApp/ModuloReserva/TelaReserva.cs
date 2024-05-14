using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class TelaReserva : TelaBase, ITelaCadastravel
    {
        public TelaAmigo telaAmigo = null;
        public TelaRevista telaRevista = null;
        public RepositorioAmigo repositorioAmigo = null;
        public RepositorioRevista repositorioRevista = null;
        public RepositorioEmprestimo repositorioEmprestimo = null;

        public override void ExecutarOperacoesEspecificas(char operacaoEscolhida)
        {
            if (operacaoEscolhida == '3')
                EmprestimoReserva();

            if (operacaoEscolhida == '4')
                VisualizarReservasExpiradas();
        }

        public override char ApresentarSubMenu()
        {
            ApresentarCabecalho();

            Console.WriteLine("1 - Cadastrar reserva");
            Console.WriteLine("2 - Visualizar reservas cadastradas");
            Console.WriteLine("3 - Cadastrar empréstimo a partir da reserva");
            Console.WriteLine("4 - Visualizar reservas expiradas");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public override EntidadeBase ObterCadastro()
        {
            telaAmigo.VisualizarCadastros(false);

            Console.WriteLine("Digite o Id do amigo que deseja realizar uma reserva: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            telaRevista.VisualizarCadastros(false);

            Console.WriteLine("Digite o Id da revista que deseja reservar: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPeloId(idAmigo);
            Revista revista = (Revista)repositorioRevista.SelecionarPeloId(idRevista);

            Reserva reserva = new Reserva(amigo, revista);

            return reserva;
        }

        public override void VisualizarCadastros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando reservas cadastradas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -20} | {3, -20}",
                "Id",
                "Amigo",
                "Revista",
                "Data de Abertura"
                );

            List<EntidadeBase> reservasCadastradas = repositorio.SelecionarTodos();

            foreach (var reserva in reservasCadastradas)
            {
                Reserva r = (Reserva)reserva;

                Console.WriteLine(
                    "{0, -5} | {1, -15} | {2, -20} | {3, -20}",
                    r.Id,
                    r.Amigo.Nome,
                    r.Revista.Titulo,
                    r.DataAbertura.ToShortDateString()
                    );
            }

            Console.ReadLine();
        }

        public void EmprestimoReserva()
        {
            VisualizarCadastros(true);
            Console.Write("Qual reserva você deseja utilizar:");
            int idReserva = Convert.ToInt32(Console.ReadLine());
            Reserva reserva = (Reserva)repositorio.SelecionarPeloId(idReserva);

            if (reserva.EstaExpirada())
                ExibirMensagem("Esta reserva está expirada!", ConsoleColor.Red);
            
            else
            {
                Emprestimo emprestimo = new Emprestimo(reserva.Amigo, reserva.Revista);
                repositorioEmprestimo.Cadastrar(emprestimo);
                reserva.Expirada = true;
                ExibirMensagem("Empréstimo realizado com sucesso", ConsoleColor.Green);
            }

            Console.ReadLine();
        }

        public void VisualizarReservasExpiradas()
        {
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10}",
                "Id",
                "Nome",
                "Revista"
                );

            foreach (var reserva in repositorio.cadastros)
            {
                Reserva r = (Reserva)reserva;

                if (r.EstaExpirada())
                {
                    Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10}",
                    r.Id,
                    r.Amigo.Nome,
                    r.Revista.Titulo
                    );
                }
            }

            Console.ReadLine();
        }

        public override void CadastrarEntidadeTeste()
        {
            Reserva reserva = new Reserva((Amigo)repositorioAmigo.SelecionarPeloId(1), (Revista)repositorioRevista.SelecionarPeloId(1));

            repositorio.Cadastrar(reserva);
        }
    }
}
