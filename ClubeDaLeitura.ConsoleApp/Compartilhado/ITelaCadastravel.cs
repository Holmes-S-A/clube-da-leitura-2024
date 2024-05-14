using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    public interface ITelaCadastravel
    {
        char ApresentarSubMenu();

        void ExecutarOperacoesEspecificas(char opcao);

        void Cadastrar();

        void VisualizarCadastros(bool exibirTitulo);
    }
}
