using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Amigo
{
    public class Amigo
    {
        public string Nome { get; set; } 
        
        public string NomeResponsavel { get; set; } 
        
        public string Telefone { get; set; } 
        
        public string Endereco { get; set; } 
        
        public Multa[] HistoricoMultas { get; set; } 
        
        public void Validar()
        {
            throw new NotImplementedException();
        }
    }
}