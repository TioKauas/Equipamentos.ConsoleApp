using Equipamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace Equipamentos.ConsoleApp.Equipamentos
{
    internal class TelaEquipamento : Tela
    {
        public RepositorioEquipamentos repositorioEquipamentos = null;

        public string apresentarMenuEquipamentos()
        {
            Console.Clear();

            Console.WriteLine("Cadastro de Equipamentos");

            Console.WriteLine();

            Console.WriteLine("1 - Adicionar equipamento");
            Console.WriteLine("2 - Vizualizar equipametnos");
            Console.WriteLine("3 - Editar equipamento");
            Console.WriteLine("4 - Excluir equipamento\n");

            Console.WriteLine("V - Voltar");

            ConsoleKeyInfo Opc = Console.ReadKey();

            return Opc.Key.ToString();
        }

        public void InserirEquipamento()
        {
            mostrarCabecalho("Cadastro de equipamento", "Inserindo novo equipamento: ");

            EntidadeEquipamento novoEquipamento = ObterEquipamentos();

            ArrayList erros = novoEquipamento.Validar();

            if (erros.Count > 0)
            {
                apresentarErros(erros);
                return;
            }

            repositorioEquipamentos.Inserir(novoEquipamento);

            apresentarMensagem("Equipamento inserido com sucesso!", ConsoleColor.Green);
        }

        public void EditarEquipamento()
        {
            mostrarCabecalho("Cadastro de Equipamentos", "Editando Equipamento: ");

            bool temEquipamentos = VizualizarEquipamentos(false);

            if (temEquipamentos) 
            {
                return;
            }

            Console.WriteLine();

            int idSelecionado = EncontrarIdEquipamento();

            EntidadeEquipamento equipamentoAtualizado = ObterEquipamentos();

            ArrayList erros = equipamentoAtualizado.Validar();

            if (erros.Count > 0)
            {
                apresentarErros(erros);
                return;
            }

            repositorioEquipamentos.Editar(idSelecionado, equipamentoAtualizado);

            apresentarMensagem("Equipamento editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirEquipamento()
        {
            mostrarCabecalho("Cadastro de Equipamentos", "Excluindo Equipamentos: ");

            bool temEquipametnosGravados = VizualizarEquipamentos(false);

            if (temEquipametnosGravados == false)
            {
                return;
            }

            Console.WriteLine();

            int idSelecionado = EncontrarIdEquipamento();

            repositorioEquipamentos.Excluir(idSelecionado);

            apresentarMensagem("Equipamento excluído com sucesso!", ConsoleColor.Green);
        }

        public bool VizualizarEquipamentos(bool MostrarCabecalho)
        {
            Console.Clear();

            ArrayList listaEquipametnos = repositorioEquipamentos.SelecionarTodos(); ;

            if (MostrarCabecalho)
            {
                mostrarCabecalho("Cadastro de Equipamentos", "Vizualizar Equipametnos");
            }

            if (listaEquipametnos.Count == 0)
            {
                apresentarMensagem("Nenhum equipamento cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0, -10} | {1, -40} | {2, -30}", "Id", "Nome", "Fabricante");

            Console.WriteLine("---------------------------------------------------------------------------------------");

            foreach (EntidadeEquipamento e in listaEquipametnos) 
            {
                Console.WriteLine("{0, 10} | {1, -40} | {2, -30}", e.id, e.Nome, e.Fabricante);
            }

            Console.ResetColor();

            return true;
        }

        public int EncontrarIdEquipamento()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o id do equipamento: ");
                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioEquipamentos.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                {
                    apresentarMensagem("Id inválido, tente novamente...", ConsoleColor.Red);
                }

            } while (idInvalido);

            return idSelecionado;
        }

        private static EntidadeEquipamento ObterEquipamentos()
        {
            Console.Clear();

            EntidadeEquipamento equipamentos = new EntidadeEquipamento();
            
            Console.Write("Nome do equipamento: ");
            equipamentos.Nome = Console.ReadLine();

            Console.Write("Preço do equipamento: ");
            equipamentos.Preco = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Número de série: ");
            equipamentos.numSerie = Console.ReadLine();

            Console.Write("Data de fabricação: ");
            equipamentos.dataFabricacao = Console.ReadLine();

            Console.Write("Fabricante: ");
            equipamentos.Fabricante = Console.ReadLine();

            return equipamentos;
        }
    }
}
