using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Caixa
{
    public class Caixa
    {
        public Revista[] Revistas { get; set; }
        
        public string Cor { get; set; }
        
        public string Etiqueta { get; set; }
        
        public int TempoEmprestimo { get; set; }
    }
}