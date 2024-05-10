using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioAmigo repositorioAmigo = new RepositorioAmigo();
            TelaAmigo telaAmigo = new TelaAmigo();
            telaAmigo.tipoEntidade = "Amigo";
            telaAmigo.repositorio = repositorioAmigo;
            telaAmigo.CadastrarEntidadeTeste();

            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            TelaCaixa telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;
            telaCaixa.CadastrarEntidadeTeste();

            RepositorioRevista repositorioRevista = new RepositorioRevista();
            TelaRevista telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.repositorio = repositorioRevista;
            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.CadastrarEntidadeTeste();

            RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
            TelaEmprestimo telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Empréstimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;
            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.telaRevista = telaRevista;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.CadastrarEntidadeTeste();

            RepositorioReserva repositorioReserva = new RepositorioReserva();
            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.repositorio = repositorioReserva;
            telaReserva.telaAmigo = telaAmigo;
            telaReserva.telaRevista = telaRevista;
            telaReserva.repositorioAmigo = repositorioAmigo;
            telaReserva.repositorioRevista = repositorioRevista;
            telaReserva.repositorioEmprestimo = repositorioEmprestimo;
            telaReserva.CadastrarEntidadeTeste();

            while (true)
            {
                char operacaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (operacaoPrincipalEscolhida == 'S' || operacaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (operacaoPrincipalEscolhida == '1')
                    tela = telaAmigo;

                else if (operacaoPrincipalEscolhida == '2')
                    tela = telaCaixa;

                else if (operacaoPrincipalEscolhida == '3')
                    tela = telaRevista;

                else if (operacaoPrincipalEscolhida == '4')
                    tela = telaEmprestimo;

                else if (operacaoPrincipalEscolhida == '5')
                    tela = telaReserva;

                char operacaoEscolhida = tela.ApresentarSubMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Cadastrar();

                if (operacaoEscolhida == '2')
                    tela.VisualizarCadastros(true);

                tela.ExecutarOperacoesEspecificas(operacaoEscolhida);
            }
            Console.ReadLine();
        }
    }
}

