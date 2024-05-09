using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    internal class RepositorioEmprestimo : RepositorioBase
    {
        public void VisualizarEmprestimosMensais()
        {
            Console.Write("Digite o número do mês desejado para visualização: ");
            bool converteu = Int32.TryParse(Console.ReadLine(), out int mes);

            if (!converteu)
            {
                Console.WriteLine("Valor digitado é inválido. Tente novamente!");
            }
            else
            {
                Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3, -10}",
                "Id", "Amigo", "Revista", "Data de Emprestimo"
                );

                foreach (var emprestimo in cadastros)
                {
                    Emprestimo e = (Emprestimo)emprestimo;

                    if (e.DataEmprestimo.Month == mes)
                    {
                        Console.WriteLine(
                        "{0, -10} | {1, -20} | {2, -10} | {3, -10}",
                        e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo
                        );
                    }
                }
            }
        }
        public void VisualizarEmprestimosEmAberto()
        {
            Console.WriteLine(
               "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -10}",
               "Id", "Amigo", "Revista", "Data de Emprestimo", "Data de Devolução"
               );

            foreach (var emprestimo in cadastros)
            {
                Emprestimo e = (Emprestimo)emprestimo;

                if (!e.Concluido)
                {
                    Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -10} | {3, -10} | {4, -10}",
                    e.Id, e.Amigo.Nome, e.Revista.Titulo, e.DataEmprestimo, e.DataDevolucao
                    );
                }
            }
        }
    }
}
