using System.Collections;

namespace Equipamentos.ConsoleApp.Compartilhado
{
    internal class Repositorio
    {
        public int contadorId = 1;

        public ArrayList listaRegistro = new ArrayList();

        public void Inserir(Entidade registro)
        {
            registro.id = contadorId;

            listaRegistro.Add(registro);
        }

        public void Editar(int id, Entidade resgistroAtualizado)
        {
            Entidade registro = SelecionarPorId(id);

            registro.Atualizar(resgistroAtualizado);
        }

        public void Excluir(int id)
        {
            Entidade registro = SelecionarPorId(id);

            listaRegistro.Remove(registro);
        }

        public Entidade SelecionarPorId(int id)
        {
            Entidade registro = null;

            foreach(Entidade e in listaRegistro)
            {
                if (e.id == id)
                {
                    registro = e;
                    break;
                }
            }

            return registro;
        }

        public ArrayList SelecionarTodos()
        {
            return listaRegistro;
        }

        public void IncrementarID()
        {
            contadorId++;
        }
    }
}
