using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista
{
    public class Revista : EntidadeBase
    {
        public string Titulo { get; set; } 
        
        public int NumeroEdicao { get; set; } 
        
        public int Ano { get; set; } 
        
        public Caixa Caixa { get; set; }

        public Revista (string titulo, int numeroEdicao, int ano, Caixa caixa)
        {
            Titulo = titulo;
            NumeroEdicao = numeroEdicao;
            Ano = ano;
            Caixa = caixa;
        }

        public override List<string> Validar()
        {
            List<string> erros = new List<string>();

            if (string.IsNullOrEmpty(Titulo))
                erros.Add("O \"título\" da revista precisa ser preenchido");

            if (NumeroEdicao <= 0)
                erros.Add("O \"número da edição\" da revista precisa ser maior que zero");

            if (Ano <= 0)
                erros.Add("O \"ano\" da revista precisa ser maior que zero");

            if (Caixa == null)
                erros.Add("O id da \"caixa\" deve ser preenchido");

            return erros;
        }
    }
}