using AtividadeAvaliativa.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.Classes.Util
{
    internal class AdicionarProduto : IOperacaoEstoque
    {
        public void Executar(Estoque estoque)
        {
            try
            {
                if (estoque.EstoqueCheio())
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Quantidade máxima de itens excedida!");
                    Console.ResetColor();
                    Sair();
                }

                Console.Write("Informe o código do produto: ");
                int codigo = Convert.ToInt32(Console.ReadLine());

                while (!estoque.CodigoDisponivel(codigo))
                {
                    Console.Write("Código indisponível! Selecione outro: ");
                    codigo = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Informe o nome do produto: ");
                string nome = Console.ReadLine();
                Console.Write("Informe a quantidade que entrará no estoque: ");
                int qtdEstoque = Convert.ToInt32(Console.ReadLine());
                while (qtdEstoque <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("A quantidade informada é inválida!");
                    Console.ResetColor();
                    Console.Write("Informe outra quantidade: ");
                    qtdEstoque = Convert.ToInt32(Console.ReadLine());

                }
                Console.Write("Informe o preço unitário do produto: ");
                double precoUnitario = Convert.ToDouble(Console.ReadLine());
                Console.Write("O produto estará disponível? ");
                string entrada = Console.ReadLine().ToLower();
                bool disponibilidade = entrada[0] == 's';

                Produto produto = new Produto(codigo, nome, qtdEstoque, precoUnitario, disponibilidade);
                estoque.AdicionarProduto(produto);
                Sair();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
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
