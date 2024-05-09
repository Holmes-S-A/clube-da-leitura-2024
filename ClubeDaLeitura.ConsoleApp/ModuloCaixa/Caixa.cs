using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa
    {
        public string Cor { get; set; }
        
        public string Etiqueta { get; set; }
        
        public int TempoEmprestimo { get; set; }

        public ArrayList Revistas { get; set; }
    }
}