using AtividadeAvaliativa.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.Classes.Util
{
    internal class AtualizarEstoque : IOperacaoEstoque
    {
        public void Executar(Estoque estoque)
        {
            try {
                if (estoque.TemProdutosCadastrados())
                {
                    Console.Write("Informe o código do produto que terá a quantidade em estoque alterada: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    if (estoque.ConsultarProdutoDisponivel(codigo) == null)
                    {
                        Sair();
                        return;
                    }
                    Console.Write("Qual a nova quantidade? ");
                    int quantidade = Convert.ToInt32(Console.ReadLine());
                    estoque.AtualizarEstoque(codigo, quantidade);
                }
                Sair();
            }catch (Exception e) 
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
