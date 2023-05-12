using System.Collections;
using Equipamentos.ConsoleApp.Compartilhado;

namespace Equipamentos.ConsoleApp.Equipamentos
{
    internal class EntidadeEquipamento : Entidade
    {
        public int id;
        public string Nome;
        public decimal Preco;
        public string numSerie;
        public string dataFabricacao;
        public string Fabricante;

        public ArrayList Validar()
        {
            ArrayList Erros = new ArrayList();

            if (Nome.Length <= 6)
            {
                Erros.Add("Nome inválido. Informe no mínimo 6 letras");
            }

            if (Fabricante.Length <= 6)
            {
                Erros.Add("Nome inválido. Informe no mínimo 6 letras");
            }

            if (numSerie.IndexOf("-") < 0)
            {
                Erros.Add("Número de série inválido. Informe um número com \"-\" ");
            }

            return Erros;
        }

        public override void Atualizar(Entidade equipamentoAtualizado)
        {
            EntidadeEquipamento equipamentos = (EntidadeEquipamento)equipamentoAtualizado;

            Nome = equipamentos.Nome;
            Preco = equipamentos.Preco;
            numSerie = equipamentos.numSerie;
            dataFabricacao = equipamentos.dataFabricacao;
            Fabricante = equipamentos.Fabricante;
        }
    }
}