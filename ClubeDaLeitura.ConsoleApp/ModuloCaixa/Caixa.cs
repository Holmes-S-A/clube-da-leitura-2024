using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    public class Caixa : EntidadeBase
    {
        public string Cor { get; set; }
        
        public string Etiqueta { get; set; }
        
        public int DiasEmprestimo { get; set; }

        public List<Revista> Revistas { get; set; }

        public Caixa(string cor, string etiqueta, int diasEmprestimo)
        {
            Cor = cor;
            Etiqueta = etiqueta;
            DiasEmprestimo = diasEmprestimo;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Cor))
                erros.Add("A \"cor\" da caixa deve ser preenchida");

            if (string.IsNullOrEmpty(Etiqueta))
                erros.Add("A \"etiqueta\" da caixa deve ser preenchida");

            if (DiasEmprestimo <= 0)
                erros.Add("O \"tempo\" de empréstimo deve ser maior que zero");

            return erros;
        }
    }
}