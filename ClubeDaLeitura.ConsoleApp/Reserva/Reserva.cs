using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Reserva
{
    public class Reserva
    {
        public DateTime DataAbertura { get; set; }
        
        public Amigo Amigo { get; set; }

        public Revista Revista { get; set; }

        public bool Expirada { get; set; }
    }
}