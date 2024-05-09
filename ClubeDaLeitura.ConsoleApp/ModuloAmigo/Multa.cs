using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp
{
    public class Multa
    {
        public decimal Valor { get; set; }
        
        public DateTime Data { get; set; }

        public bool EstaPaga { get; set; }
    }
}