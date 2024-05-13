using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class TelaCaixa : TelaBase
    {
        public override void ExecutarOperacoesEspecificas(char operacaoEscolhida)
        {
        }

        public override char ApresentarSubMenu()
        {
            ApresentarCabecalho();

            Console.WriteLine("1 - Cadastrar caixa");
            Console.WriteLine("2 - Visualizar caixas cadastradas");

            Console.WriteLine("S - Voltar");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");
            char operacaoEscolhida = Convert.ToChar(Console.ReadLine());

            return operacaoEscolhida;
        }

        public override EntidadeBase ObterCadastro()
        {
            Console.Write("Digite a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            Console.Write("Digite a quantidade de dias de empréstimo: ");
            int diasEmprestimo = Convert.ToInt32(Console.ReadLine());

            Caixa caixa = new Caixa(cor, etiqueta, diasEmprestimo);

            return caixa;
        }

        public override void VisualizarCadastros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando caixas cadastradas...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -5} | {1, -15} | {2, -20} | {3, -20}",
                "Id",
                "Cor",
                "Etiqueta",
                "Quantidade de Dias de Empréstimo"
                );

            List<EntidadeBase> caixasCadastradas = repositorio.SelecionarTodos();

            foreach (var caixa in caixasCadastradas)
            {
                Caixa c = (Caixa)caixa;

                Console.WriteLine(
                    "{0, -5} | {1, -15} | {2, -20} | {3, -20}",
                    c.Id,
                    c.Cor,
                    c.Etiqueta,
                    c.DiasEmprestimo
                    );
            }

            Console.ReadLine();
        }

        public override void CadastrarEntidadeTeste()
        {
            Caixa caixa = new Caixa("Roxo", "Novidade", 3);

            repositorio.Cadastrar(caixa);
        }
    }
}
