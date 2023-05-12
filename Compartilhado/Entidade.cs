namespace Equipamentos.ConsoleApp.Compartilhado
{
    internal class Entidade
    {
        public int id;

        public virtual void Atualizar(Entidade registroAtualizado)
        {
            id = registroAtualizado.id;
        }

    }
}
