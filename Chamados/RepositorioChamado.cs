using Equipamentos.ConsoleApp.Compartilhado;
using Equipamentos.ConsoleApp.Equipamentos;

namespace Equipamentos.ConsoleApp.Chamados
{
    internal class RepositorioChamado : Repositorio
    {
        public RepositorioEquipamentos repositorioEquipamentos = null;

        public EntidadeChamado Chamados
        {
            get => default;
            set { }
        }
    
        public void CadastrarAlgunsChamadosAutomaticamente()
        {
            EntidadeChamado chamado = new EntidadeChamado();

            chamado.id = contadorId;
            chamado.titulo = "Impressão fraca";
            chamado.descricao = "Mesmo trocando o toner, impressão continua fraca";
            chamado.dataAbertura = "04/04/2023";
            chamado.equipamento = (EntidadeEquipamento)repositorioEquipamentos.SelecionarPorId(1);

            listaRegistro.Add(chamado);

            contadorId++;
        }
    }
}
