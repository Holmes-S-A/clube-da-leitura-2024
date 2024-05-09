using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    public class Reserva : EntidadeBase
    {
        public DateTime DataAbertura { get; set; }

        public Amigo Amigo { get; set; }

        public Revista Revista { get; set; }

        public Reserva (Amigo amigo, Revista revista)
        {
            DataAbertura = DateTime.Now;
            Amigo = amigo;
            Revista = revista;
        }

        public bool ReservaEstaExpirada()
        {
            return (DateTime.Now - DataAbertura).Days > 2;
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (Amigo == null)
                erros.Add("O Id do \"amigo\" que reservará a revista deve ser preenchido");

            if (Revista == null)
                erros.Add("O  da \"revista\" que será reservada deve ser preenchido");

            return erros;
        }
    }
}
