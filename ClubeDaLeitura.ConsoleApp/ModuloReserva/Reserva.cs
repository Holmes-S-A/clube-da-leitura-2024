using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System.Collections;


namespace ClubeDaLeitura.ConsoleApp.ModuloReserva
{
    public class Reserva : EntidadeBase
    {
        public Amigo Amigo { get; set; }

        public Revista Revista { get; set; }
        
        public DateTime DataAbertura { get; set; }

        public bool Expirada { private get; set; }

        public Reserva (Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataAbertura = DateTime.Now;
            Expirada = false;
        }

        public bool EstaExpirada()
        {
            Expirada = (DateTime.Now - DataAbertura).Days > 2 || Expirada;
            return Expirada;
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
