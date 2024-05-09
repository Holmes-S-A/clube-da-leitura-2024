using ClubeDaLeitura.ConsoleApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class RepositorioAmigo : RepositorioBase
    {
        public void RegistrarMulta()
        {
            Multa multa = new Multa();
            multa.Valor = 10.00m;
            multa.Data = DateTime.Now;
            multa.EstaPaga = false;


            Console.Write("Qual o Id do amigo que possui multa? ");
            int amigoQueReceberaAMulta = Convert.ToInt32(Console.ReadLine());

            Amigo a = (Amigo)SelecionarPeloId(amigoQueReceberaAMulta);

            if (a != null)
                a.HistoricoMultas.Add(multa);

            else
                Console.WriteLine("Id não encontrado!");
        }
        public void VisualizarAmigosComMultaEmAberto()
        {
            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -10} | {3, -10}",
                "Id", "Nome", "Valor da Multa", "Data da Multa"
                );

            foreach (var amigo in cadastros)
            {
                Amigo a = (Amigo)amigo;

                foreach (var multa in a.HistoricoMultas)
                {
                    Multa m = (Multa)multa;

                    if (!m.EstaPaga)
                    {
                        Console.WriteLine(
                        "{0, -10} | {1, -20} | {2, -10} | {3, -10}",
                        a.Id, a.Nome, m.Valor, m.Data
                        );
                    }
                }
            }
        }
        public void QuitarMulta()
        {
            Console.Write("Qual o Id do amigo que deseja quitar a multa? ");
            int amigoQueDesejaQuitarAMulta = Convert.ToInt32(Console.ReadLine());

            Amigo a = (Amigo)SelecionarPeloId(amigoQueDesejaQuitarAMulta);

            foreach (var multa in a.HistoricoMultas)
            {
                Multa m = (Multa)multa;

                if (!m.EstaPaga)
                {
                    m.EstaPaga = true;
                    Console.WriteLine("Multa quitada com sucesso!");
                }
            }
        }
    }
}
