using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    internal class TelaRevista : TelaBase
    {
        public TelaCaixa telaCaixa = null;
        public RepositorioCaixa repositorioCaixa = null;

        public override void ExecutarOperacoesEspecificas(char operacaoEscolhida)
        {
        }

        public override char ApresentarSubMenu()
        {
            ApresentarCabecalho();

            Console.WriteLine("1 - Cadastrar revista ");
            Console.WriteLine("2 - Visualizar revistas cadastradas");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public override EntidadeBase ObterCadastro()
        {
            Console.Write("Digite o título da revista: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o número da edição da revista: ");
            int edicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano da revista: ");
            int ano = Convert.ToInt32(Console.ReadLine());

            telaCaixa.VisualizarCadastros(false);

            Console.Write("Digite o id da caixa que contém a revista: ");
            int idCaixa = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = (Caixa)repositorioCaixa.SelecionarPeloId(idCaixa);

            Revista revista = new Revista(titulo, edicao, ano, caixa);

            return revista;
        }

        public override void VisualizarCadastros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando revistas cadastradas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -40} | {2, -10} | {3, -10} | {4, -5}",
                "Id",
                "Revista",
                "Edição",
                "Ano",
                "Caixa"
                );

            ArrayList revistasCadastradas = repositorio.SelecionarTodos();

            foreach (var revista in revistasCadastradas)
            {
                Revista r = (Revista)revista;

                Console.WriteLine(
                    "{0, -5} | {1, -40} | {2, -10} | {3, -10} | {4, -5}",
                    r.Id,
                    r.Titulo,
                    r.NumeroEdicao,
                    r.Ano,
                    r.Caixa.Etiqueta
                    );
            }

            Console.ReadLine();
        }
        public override void CadastrarEntidadeTeste()
        {
            Revista revista = new Revista("O Espetacular Homem Aranha", 15, 2020, (Caixa)repositorioCaixa.SelecionarPeloId(1));

            repositorio.Cadastrar(revista);
        }
    }
}

