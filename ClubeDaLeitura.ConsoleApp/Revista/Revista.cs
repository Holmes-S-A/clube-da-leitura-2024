using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Revista
{
    public class Revista
    {
        public string Titulo { get; set; } 
        
        public int NumeroEdicao { get; set; } 
        
        public int Ano { get; set; } 
        
        public Caixa Caixa { get; set; } 
    }
}