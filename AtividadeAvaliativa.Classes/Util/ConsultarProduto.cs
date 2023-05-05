using AtividadeAvaliativa.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.Classes.Util
{
    internal class ConsultarProduto : IOperacaoEstoque
    {
        public void Executar(Estoque estoque)
        {
            try
            {
                if (estoque.TemProdutosCadastrados())
                {
                    Console.Write("Informe o código do produto que deseja consultar: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    Produto query = estoque.ConsultarProdutoDisponivel(codigo);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(query);
                    Console.ResetColor();
                }
                Sair();
            } catch (Exception e) 
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e);
                Console.ResetColor();
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
