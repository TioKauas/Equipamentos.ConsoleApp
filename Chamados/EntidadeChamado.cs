using System.Collections;
using Equipamentos.ConsoleApp.Compartilhado;
using Equipamentos.ConsoleApp.Equipamentos;

namespace Equipamentos.ConsoleApp.Chamados
{
    internal class EntidadeChamado : Entidade
    {
        public string titulo;
        public string descricao;
        public string dataAbertura;

        public EntidadeEquipamento equipamento;

        public ArrayList Validar()
        {
            ArrayList erros = new ArrayList();

            if (string.IsNullOrEmpty(titulo))
            {
                erros.Add("O título é obrigatório");
            }

            if (equipamento == null)
            {
                erros.Add("O equipamento é obrigatório");
            }

            return erros;
        }

        public override void Atualizar(Entidade chamadoAtualizado)
        {
            EntidadeChamado chamado = (EntidadeChamado)chamadoAtualizado;

            titulo = chamado.titulo;
            descricao = chamado.descricao;
            dataAbertura = chamado.dataAbertura;
            equipamento = chamado.equipamento;
        }
    }
}
