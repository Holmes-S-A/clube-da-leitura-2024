using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            RepositorioReserva repositorioReserva = new RepositorioReserva();
            TelaReserva telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.repositorio = repositorioReserva;

            while (true)
            {
                char opcaoPrincipalEscolhida = TelaPrincipal.ApresentarMenuPrincipal();

                if (opcaoPrincipalEscolhida == 'S' || opcaoPrincipalEscolhida == 's')
                    break;

                TelaBase tela = null;

                if (opcaoPrincipalEscolhida == '1')
                    tela = tela;

                else if (opcaoPrincipalEscolhida == '2')
                    tela = tela;

                else if (opcaoPrincipalEscolhida == '3')
                    tela = tela;

                else if (opcaoPrincipalEscolhida == '4')
                    tela = tela;

                else if (opcaoPrincipalEscolhida == '5')
                    tela = telaReserva;

                else if (opcaoPrincipalEscolhida == '6')
                    tela = tela;

                char operacaoEscolhida = tela.ApresentarMenu();

                if (operacaoEscolhida == 'S' || operacaoEscolhida == 's')
                    continue;

                if (operacaoEscolhida == '1')
                    tela.Cadastrar();

                //else if (operacaoEscolhida == '2')
                //    tela.();

                //else if (operacaoEscolhida == '3')
                //    tela.();

                //else if (operacaoEscolhida == '4')
                //    tela.;
            }
            Console.ReadLine();
        }
    }
}

