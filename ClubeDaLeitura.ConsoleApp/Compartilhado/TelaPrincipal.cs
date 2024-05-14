using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloEmprestimo;
using ClubeDaLeitura.ConsoleApp.ModuloReserva;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        RepositorioAmigo repositorioAmigo;
        TelaAmigo telaAmigo;

        RepositorioCaixa repositorioCaixa;
        TelaCaixa telaCaixa;

        RepositorioRevista repositorioRevista;
        TelaRevista telaRevista;

        RepositorioEmprestimo repositorioEmprestimo;
        TelaEmprestimo telaEmprestimo;

        RepositorioReserva repositorioReserva;
        TelaReserva telaReserva;

        public TelaPrincipal()
        {
            repositorioAmigo = new RepositorioAmigo();
            telaAmigo = new TelaAmigo();
            telaAmigo.tipoEntidade = "Amigo";
            telaAmigo.repositorio = repositorioAmigo;
            telaAmigo.CadastrarEntidadeTeste();

            repositorioCaixa = new RepositorioCaixa();
            telaCaixa = new TelaCaixa();
            telaCaixa.tipoEntidade = "Caixa";
            telaCaixa.repositorio = repositorioCaixa;
            telaCaixa.CadastrarEntidadeTeste();

            repositorioRevista = new RepositorioRevista();
            telaRevista = new TelaRevista();
            telaRevista.tipoEntidade = "Revista";
            telaRevista.repositorio = repositorioRevista;
            telaRevista.telaCaixa = telaCaixa;
            telaRevista.repositorioCaixa = repositorioCaixa;
            telaRevista.CadastrarEntidadeTeste();

            repositorioEmprestimo = new RepositorioEmprestimo();
            telaEmprestimo = new TelaEmprestimo();
            telaEmprestimo.tipoEntidade = "Empréstimo";
            telaEmprestimo.repositorio = repositorioEmprestimo;
            telaEmprestimo.telaAmigo = telaAmigo;
            telaEmprestimo.telaRevista = telaRevista;
            telaEmprestimo.repositorioAmigo = repositorioAmigo;
            telaEmprestimo.repositorioRevista = repositorioRevista;
            telaEmprestimo.CadastrarEntidadeTeste();

            repositorioReserva = new RepositorioReserva();
            telaReserva = new TelaReserva();
            telaReserva.tipoEntidade = "Reserva";
            telaReserva.repositorio = repositorioReserva;
            telaReserva.telaAmigo = telaAmigo;
            telaReserva.telaRevista = telaRevista;
            telaReserva.repositorioAmigo = repositorioAmigo;
            telaReserva.repositorioRevista = repositorioRevista;
            telaReserva.repositorioEmprestimo = repositorioEmprestimo;
            telaReserva.CadastrarEntidadeTeste();
        }
        public ITelaCadastravel ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube da Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gerenciar amigo");
            Console.WriteLine("2 - Gerenciar caixa de revistas");
            Console.WriteLine("3 - Gerenciar revista");
            Console.WriteLine("4 - Gerenciar empréstimo");
            Console.WriteLine("5 - Gerenciar reserva");

            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char operacaoPrincipalEscolhida = Convert.ToChar(Console.ReadLine());

            ITelaCadastravel tela = null;

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

            return tela;
        }
    }
}
