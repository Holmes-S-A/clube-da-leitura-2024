using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo : TelaBase, ITelaCadastravel
    {
        public override void ExecutarOperacoesEspecificas(char operacaoEscolhida)
        {
            if (operacaoEscolhida == '3')
                VisualizarAmigosComMultaEmAberto();

            if (operacaoEscolhida == '4')
                QuitarMulta();
        }

        public override char ApresentarSubMenu()
        {
            ApresentarCabecalho();

            Console.WriteLine("1 - Cadastrar amigo");
            Console.WriteLine("2 - Visualizar amigos cadastrados");
            Console.WriteLine("3 - Visualizar amigos com multa em aberto");
            Console.WriteLine("4 - Quitar multa em aberto");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

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

        public override void VisualizarCadastros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando amigos cadastrados...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, -20}",
                "Id",
                "Nome",
                "Nome do Responsável",
                "Telefone",
                "Endereço"
                );

            List<EntidadeBase> amigosCadastrados = repositorio.SelecionarTodos();

            foreach (var amigo in amigosCadastrados)
            {
                Amigo a = (Amigo)amigo;

                Console.WriteLine(
                    "{0, -5} | {1, -15} | {2, -20} | {3, -20} | {4, -5}",
                    a.Id,
                    a.Nome,
                    a.NomeResponsavel,
                    a.Telefone,
                    a.Endereco
                    );
            }

            Console.ReadLine();
        }

        public void RegistrarMulta(Amigo amigo)
        {
            Multa multa = new Multa();
            multa.Valor = 10.00m;
            multa.Data = DateTime.Now;
            multa.EstaPaga = false;

            amigo.HistoricoMultas.Add(multa);
        }

        public void VisualizarAmigosComMultaEmAberto()
        {
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                "Id", 
                "Nome", 
                "Valor da Multa", 
                "Data da Multa"
                );

            foreach (var amigo in repositorio.cadastros)
            {
                Amigo a = (Amigo)amigo;

                foreach (var multa in a.HistoricoMultas)
                {
                    Multa m = (Multa)multa;

                    if (!m.EstaPaga)
                    {
                        Console.WriteLine(
                        "{0, -10} | {1, -20} | {2, -20} | {3, -10}",
                        a.Id, 
                        a.Nome, 
                        m.Valor, 
                        m.Data.ToShortDateString()
                        );
                    }
                }
            }
            
            Console.ReadLine();
        }

        public void QuitarMulta()
        {
            Console.Write("Qual o Id do amigo que deseja quitar a multa? ");
            int amigoQueDesejaQuitarAMulta = Convert.ToInt32(Console.ReadLine());

            Amigo a = (Amigo)repositorio.SelecionarPeloId(amigoQueDesejaQuitarAMulta);

            foreach (var multa in a.HistoricoMultas)
            {
                Multa m = (Multa)multa;

                if (!m.EstaPaga)
                {
                    m.EstaPaga = true;
                    ExibirMensagem("Multa quitada com sucesso!", ConsoleColor.Green);
                }
            }

            Console.ReadLine();
        }

        public override void CadastrarEntidadeTeste()
        {
            Amigo amigo = new Amigo("Leandro", "Nanci (mãe)", "(49) 99907-2202", "Rua Lourenço, 612, Bairro Sagrado");

            repositorio.Cadastrar(amigo);
        }
    }
}
