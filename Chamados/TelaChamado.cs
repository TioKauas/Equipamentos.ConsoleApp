using Equipamentos.ConsoleApp.Chamados;
using Equipamentos.ConsoleApp.Compartilhado;
using Equipamentos.ConsoleApp.Equipamentos;
using System.Collections;

namespace Chamados.ConsoleApp.Chamados
{
    internal class TelaChamado : Tela
    {
        public RepositorioEquipamentos repositorioEquipamento = null;
        public RepositorioChamado repositorioChamado = null;

        public TelaEquipamento telaEquipamento = null;

        public string apresentarMenuChamados()
        {

            Console.Clear();

            Console.WriteLine("Cadastro de Chamados");

            Console.WriteLine();

            Console.WriteLine("1 - Adicionar chamado");
            Console.WriteLine("2 - Vizualizar chamados");
            Console.WriteLine("3 - Editar chamado");
            Console.WriteLine("4 - Excluir chamado\n");

            Console.WriteLine("V - Voltar");

            ConsoleKeyInfo Opc = Console.ReadKey();

            return Opc.Key.ToString();
        }

        public void InserirChamado()
        {
            mostrarCabecalho("Cadastro de Chamados", "Inserindo Novo Chamado: ");

            EntidadeChamado chamado = ObterChamado();

            ArrayList erros = chamado.Validar();

            if (erros.Count > 0)
            {
                apresentarErros(erros);
                return;
            }

            repositorioChamado.Inserir(chamado);

            apresentarMensagem("Chamado inserido com sucesso!", ConsoleColor.Green);
        }

        public void InserirNovoChamado()
        {
            mostrarCabecalho("Cadastro de Chamados", "Inserindo Novo Chamado: ");

            EntidadeChamado chamado = ObterChamado();

            ArrayList erros = chamado.Validar();

            if (erros.Count > 0)
            {
                apresentarErros(erros);
                return;
            }

            repositorioChamado.Inserir(chamado);

            apresentarMensagem("Chamado inserido com sucesso!", ConsoleColor.Green);
        }

        public void EditarChamado()
        {
            mostrarCabecalho("Controle de Chamados", "Editando Chamado: ");

            bool temChamados = VisualizarChamados(false);

            if (temChamados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdChamado();

            EntidadeChamado chamadoAtualizado = ObterChamado();

            ArrayList erros = chamadoAtualizado.Validar();

            if (erros.Count > 0)
            {
                apresentarErros(erros);
                return;
            }

            repositorioChamado.Editar(idSelecionado, chamadoAtualizado);

            apresentarMensagem("Chamado editado com sucesso!", ConsoleColor.Green);
        }

        public void ExcluirChamado()
        {
            mostrarCabecalho("Controle de Chamados", "Excluindo Chamado: ");

            bool temChamados = VisualizarChamados(false);

            if (temChamados == false)
                return;

            Console.WriteLine();

            int idSelecionado = EncontrarIdChamado();

            repositorioChamado.Excluir(idSelecionado);

            apresentarMensagem("Chamado excluído com sucesso!", ConsoleColor.Green);
        }

        public bool VisualizarChamados(bool MostrarCabecalho)
        {
            Console.Clear();

            ArrayList listaChamados = repositorioChamado.SelecionarTodos();

            if (MostrarCabecalho)
                mostrarCabecalho("Controle de Chamados", "Visualizando Chamados: ");

            if (listaChamados.Count == 0)
            {
                apresentarMensagem("Nenhum chamado cadastrado!", ConsoleColor.DarkYellow);
                return false;
            }

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}", "Id", "Título", "Equipamento", "Fabricante", "Data de Abertura");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");


            foreach (EntidadeChamado c in listaChamados)
            {
                Console.WriteLine("{0,-10} | {1,-40} | {2,-30} | {3,-30} | {4,-30}",
                    c.id, c.titulo, c.equipamento.Nome, c.equipamento.Fabricante, c.dataAbertura);
            }

            Console.ResetColor();

            return true;
        }


        private EntidadeChamado ObterChamado()
        {
            telaEquipamento.VizualizarEquipamentos(false);

            Console.WriteLine();

            EntidadeChamado chamado = new EntidadeChamado();

            int idEquipamento = telaEquipamento.EncontrarIdEquipamento();
            chamado.equipamento = (EntidadeEquipamento)repositorioEquipamento.SelecionarPorId(idEquipamento);

            Console.Write("Digite o título do chamado: ");
            chamado.titulo = Console.ReadLine();

            Console.Write("Digite a descricao do chamado: ");
            chamado.descricao = Console.ReadLine();

            Console.Write("Digite a data de abertura do chamado: ");
            chamado.dataAbertura = Console.ReadLine();

            return chamado;
        }

        private int EncontrarIdChamado()
        {
            int idSelecionado;
            bool idInvalido;

            do
            {
                Console.Write("Digite o Id do Chamado: ");

                idSelecionado = Convert.ToInt32(Console.ReadLine());

                idInvalido = repositorioChamado.SelecionarPorId(idSelecionado) == null;

                if (idInvalido)
                    apresentarMensagem("Id inválido, tente novamente", ConsoleColor.Red);

            } while (idInvalido);

            return idSelecionado;
        }

    }
}
