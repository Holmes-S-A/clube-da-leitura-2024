using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal class TelaPrincipal
    {
        public static char ApresentarMenuPrincipal()
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

            char opcaoEscolhida = Convert.ToChar(Console.ReadLine());

            return opcaoEscolhida;
        }
    }
}
