using AtividadeAvaliativa.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.Classes.Util
{
    internal class AlterarDisponibilidade : IOperacaoEstoque
    {
        public void Executar(Estoque estoque)
        {
            try
            {
                if (estoque.TemProdutosCadastrados())
                {
                    Console.Write("Informe o código do produto que terá a disponibilidade alterada: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());
                    if (estoque.CodigoDisponivel(codigo))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Código não cadastrado! ");
                        Console.ResetColor();
                        Sair();
                        return;
                    }
                    Console.Write("O produto estará disponível ou indisponível? ");
                    string entrada = Console.ReadLine().ToLower();
                    bool disponibilidade = entrada[0] == 'd';
                    estoque.AlterarDisponibilidade(codigo, disponibilidade);
                }
                Sair();
            } catch(Exception e) 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(e.Message);
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
