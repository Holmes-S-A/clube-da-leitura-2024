using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class TelaBase
    {
        public string tipoEntidade = "";
        public RepositorioBase repositorio = null;

        public void ApresentarCabecalho()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube da Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();
        }

        public abstract char ApresentarSubMenu();

        public abstract void ExecutarOperacoesEspecificas(char opcao);

        public abstract EntidadeBase ObterCadastro();

        public virtual void Cadastrar()
        {
            ApresentarCabecalho();

            Console.WriteLine($"Cadastrando {tipoEntidade}...");

            Console.WriteLine();

            EntidadeBase entidade = ObterCadastro();

            ArrayList erros = entidade.Validar();

            if (erros.Count > 0)
            {
                ApresentarErros(erros);
                return;
            }

            repositorio.Cadastrar(entidade);

            ExibirMensagem($"O {tipoEntidade} foi cadastrado com sucesso!", ConsoleColor.Green);
            
        }

        public abstract void VisualizarCadastros(bool exibirTitulo);

        public void ApresentarErros(ArrayList erros)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var erro in erros)
            {
                Console.WriteLine(erro);
            }
            
            Console.ResetColor();
            Console.ReadLine();
        }

        public void ExibirMensagem(string mensagem, ConsoleColor cor)
        {
            Console.ForegroundColor = cor;

            Console.WriteLine();

            Console.WriteLine(mensagem);

            Console.ResetColor();

            Console.ReadLine();
        }

        public abstract void CadastrarEntidadeTeste();
    }
}
