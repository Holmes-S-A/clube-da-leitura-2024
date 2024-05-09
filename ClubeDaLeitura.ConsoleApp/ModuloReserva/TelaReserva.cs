using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    internal class TelaReserva : TelaBase
    {
        RepositorioAmigo repositorioAmigo = null;
        RepositorioRevista repositorioRevista = null;
        public override EntidadeBase ObterCadastro()
        {
            Console.WriteLine("Digite o Id do amigo que deseja realizar uma reserva: ");
            int idAmigo = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Id da revista que deseja reservar: ");
            int idRevista = Convert.ToInt32(Console.ReadLine());

            Amigo amigo = (Amigo)repositorioAmigo.SelecionarPeloId(idAmigo);
            Revista revista = (Revista)repositorioRevista.SelecionarPeloId(idRevista);

            Reserva reserva = new Reserva(amigo, revista);

            reserva.ReservaEstaExpirada();

            return reserva;
        }
        //public void CadastrarEntidadeTeste()
        //{
        //    Reserva reserva = new Reserva();

        //    repositorio.Cadastrar(reserva);
        //}
    }
}
