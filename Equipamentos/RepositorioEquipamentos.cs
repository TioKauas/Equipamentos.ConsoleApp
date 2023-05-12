using Equipamentos.ConsoleApp.Compartilhado;

namespace Equipamentos.ConsoleApp.Equipamentos
{
    internal class RepositorioEquipamentos : Repositorio
    {
        public EntidadeEquipamento Equipamento
        { 
          get => default;
            set{}
        }

        public void CadastrarAlgunsEquipamentosAutomaticamente()
        {
            EntidadeEquipamento equipamento = new EntidadeEquipamento();

            equipamento.id = contadorId;
            equipamento.Nome = "Impressora";
            equipamento.Preco = 1500;
            equipamento.numSerie = "123-abc";
            equipamento.dataFabricacao = "12/12/2022";
            equipamento.Fabricante = "Lexmark";

            Inserir(equipamento);
        }
    }
}
