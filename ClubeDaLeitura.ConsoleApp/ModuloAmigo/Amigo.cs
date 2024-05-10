using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    public class Amigo : EntidadeBase
    {
        public string Nome { get; set; }

        public string NomeResponsavel { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public ArrayList HistoricoMultas { get; set; }

        public Amigo(string nome, string nomeResponsavel, string telefone, string endereco)
        {
            Nome = nome;
            NomeResponsavel = nomeResponsavel;
            Telefone = telefone;
            Endereco = endereco;
            HistoricoMultas = new ArrayList();
        }

        public override ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(Nome))
                erros.Add("O \"nome\" do amigo deve ser preenchido");

            if (string.IsNullOrEmpty(NomeResponsavel))
                erros.Add("O \"nome do responsável\" pelo amigo deve ser preenchido");

            if (string.IsNullOrEmpty(Telefone.Trim()))
                erros.Add("O \"telefone\" deve ser preenchido");

            if (string.IsNullOrEmpty(Endereco))
                erros.Add("O \"endereço\" deve ser preenchido");

            return erros;
        }
    }
}