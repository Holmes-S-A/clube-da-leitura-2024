using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Emprestimo
{
    public class Emprestimo
    {
        public Amigo Amigo { get; set; }
        
        public Revista Revista { get; set; }
        
        public bool Concluido { get; set; }
        
        public DateTime Data { get; set; }

        public DateTime DataDevolucao { get; set; }
    }
}