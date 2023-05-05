using AtividadeAvaliativa.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.Classes.Util
{
    internal class ListarProdutos : IOperacaoEstoque
    {
        public void Executar(Estoque estoque)
        {
            try
            {
                Console.WriteLine("PRODUTOS DISPONÍVEIS:");
                Console.ForegroundColor = ConsoleColor.Yellow;
                estoque.ListarProdutos().ForEach(p => Console.WriteLine(p));
                Console.ResetColor();
                Sair();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Sair();
            }
        }

        public void Sair()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar!");
            Console.ReadKey();
            Console.Clear();
            return;
        }
    }
}
