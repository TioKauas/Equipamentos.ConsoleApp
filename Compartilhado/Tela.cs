using System.Collections;

namespace Equipamentos.ConsoleApp.Compartilhado
{
    internal class Tela
    {
        public void apresentarMensagem(string Mensagem, ConsoleColor Cor)
        {
            Console.WriteLine();
            Console.ForegroundColor = Cor;
            Console.WriteLine(Mensagem);
            Console.ResetColor();
            Console.ReadLine();
        }

        public void mostrarCabecalho(string Titulo, string Subtitulo)
        {
            Console.WriteLine();

            Console.WriteLine(Titulo);

            Console.WriteLine();

            Console.WriteLine(Subtitulo);

            Console.WriteLine();

            Console.WriteLine();
        }

        public void apresentarErros(ArrayList erros)
        {
            Console.ForegroundColor= ConsoleColor.Red;

            foreach (string erro in erros)
            {
                Console.WriteLine(erro);
            }

            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
