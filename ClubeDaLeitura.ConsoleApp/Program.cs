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
            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (true)
            {
                ITelaCadastravel tela = telaPrincipal.ApresentarMenuPrincipal();

                if (tela == null)
                    break;

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

