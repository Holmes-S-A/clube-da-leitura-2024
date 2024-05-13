using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.ModuloEmprestimo
{
    public class Emprestimo : EntidadeBase
    {
        public Amigo Amigo { get; set; }
        
        public Revista Revista { get; set; }
        
        public DateTime DataEmprestimo { get; set; }

        public DateTime DataDevolucao { get; set; }

        public bool Concluido { get; set; }

        public Emprestimo(Amigo amigo, Revista revista)
        {
            Amigo = amigo;
            Revista = revista;
            DataEmprestimo = DateTime.Now;
            DefinirDataDevolucao();
            Concluido = false;
        }

        private void DefinirDataDevolucao()
        {
            int quantidadeDias = Revista.Caixa.DiasEmprestimo;
            DataDevolucao = DataEmprestimo.AddDays(quantidadeDias); 
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (Amigo == null)
                erros.Add("O id do \"amigo\" deve ser preenchido");

            if (Revista == null)
                erros.Add("O id da \"revista\" deve ser preenchido");

            foreach (var multa in Amigo.HistoricoMultas)
            {
                Multa m = (Multa)multa;
                if (!m.EstaPaga)
                {
                    erros.Add("O amigo possui multa em aberto!");
                    break;
                }
            }

            return erros;
        }
    }
}