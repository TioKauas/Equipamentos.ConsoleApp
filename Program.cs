using Chamados.ConsoleApp.Chamados;
using Equipamentos.ConsoleApp.Chamados;
using Equipamentos.ConsoleApp.Equipamentos;

namespace Equipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RepositorioEquipamentos repositorioEquipamento = new RepositorioEquipamentos();
            repositorioEquipamento.CadastrarAlgunsEquipamentosAutomaticamente();

            RepositorioChamado repositorioChamado = new RepositorioChamado();
            repositorioChamado.repositorioEquipamentos = repositorioEquipamento;

            repositorioChamado.CadastrarAlgunsChamadosAutomaticamente();

            TelaEquipamento telaEquipamento = new TelaEquipamento();
            telaEquipamento.repositorioEquipamentos = repositorioEquipamento;

            TelaChamado telaChamado = new TelaChamado();
            telaChamado.repositorioEquipamento = repositorioEquipamento;
            telaChamado.repositorioChamado = repositorioChamado;
            telaChamado.telaEquipamento = telaEquipamento;


            while (true)
            {
                string menu = apresentarMenu();

                if (menu == "NumPad1")
                {
                    string OpcCadastroEquipamento = telaEquipamento.apresentarMenuEquipamentos();

                    if (OpcCadastroEquipamento == "V")
                    {
                        continue;
                    }

                    if (OpcCadastroEquipamento == "NumPad1")
                    {
                        telaEquipamento.InserirEquipamento();
                    }
                    else if (OpcCadastroEquipamento == "NumPad2")
                    {
                        bool temEquipamentos = telaEquipamento.VizualizarEquipamentos(true);

                        if (temEquipamentos)
                            Console.ReadLine();
                    }
                    else if (OpcCadastroEquipamento == "NumPad3")
                    {
                        telaEquipamento.EditarEquipamento();
                    }
                    else if (OpcCadastroEquipamento == "NumPad4")
                    {
                        telaEquipamento.ExcluirEquipamento();
                    }
                }
                else if (menu == "NumPad2")
                {
                    string opcaoCadastroChamados = telaChamado.apresentarMenuChamados();

                    if (opcaoCadastroChamados == "S")
                        continue;

                    if (opcaoCadastroChamados == "NumPad1")
                    {
                        telaChamado.InserirNovoChamado();
                    }
                    else if (opcaoCadastroChamados == "NumPad2")
                    {
                        bool temChamados = telaChamado.VisualizarChamados(true);

                        if (temChamados)
                            Console.ReadLine();
                    }
                    else if (opcaoCadastroChamados == "NumPad3")
                    {
                        telaChamado.EditarChamado();
                    }
                    else if (opcaoCadastroChamados == "NumPad4")
                    {
                        telaChamado.ExcluirChamado();
                    }
                }
            }

            static string apresentarMenu()
            {
                Console.Clear();

                Console.WriteLine("Gestão de Equipamentos 1.0");

                Console.WriteLine();

                Console.WriteLine("Qual menu deseja acessar?");
                Console.WriteLine("1 - Equipamentos");
                Console.WriteLine("2 - Chamados");
                Console.WriteLine("\nS - Sair\n");
                Console.Write(">");
                ConsoleKeyInfo Opc = Console.ReadKey();

                return Opc.Key.ToString();
            }
        }
    }
}
