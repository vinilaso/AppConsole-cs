using AtividadeAvaliativa.Classes.Entidades;
using AtividadeAvaliativa.Classes.Util;
using System.Runtime.ConstrainedExecution;

namespace AtividadeAvaliativa.Classes.Aplicacao
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Estoque estoque = new Estoque();

            bool sairPrograma = false;
            while (sairPrograma == false)
            {
                // painel de seleção
                Console.WriteLine("Bem vindo! Selecione uma das opções:"
                    + "\n[a] Adicionar produto"
                    + "\n[b] Listar produtos"
                    + "\n[c] Consultar produto"
                    + "\n[d] Atualizar estoque"
                    + "\n[e] Alterar disponibilidade"
                    + "\n[f] Sair do programa");
                try
                {
                    char opcao = Convert.ToChar(Console.ReadLine().ToLower());
                    Console.Clear();

                    switch (opcao)
                    {
                        // opção [a] -> adicionar produto
                        case 'a':
                            Console.WriteLine("[a] Adicionar produto");
                            IOperacaoEstoque adicionarProduto = new AdicionarProduto();
                            adicionarProduto.Executar(estoque);
                            break;

                        // opção [b] -> listar produtos
                        case 'b':
                            Console.WriteLine("[b] Listar produtos");
                            IOperacaoEstoque listarProdutos = new ListarProdutos();
                            listarProdutos.Executar(estoque);
                            break;

                        // opção [c] -> consultar produto
                        case 'c':
                            Console.WriteLine("[c] Consultar produto");
                            IOperacaoEstoque consultarProduto = new ConsultarProduto();
                            consultarProduto.Executar(estoque);
                            break;

                        // opção [d] -> atualizar estoque
                        case 'd':
                            Console.WriteLine("[d] Atualizar estoque");
                            IOperacaoEstoque atualizarEstoque = new AtualizarEstoque();
                            atualizarEstoque.Executar(estoque);
                            break;

                        // opção [e] -> alterar disponibilidade
                        case 'e':
                            Console.WriteLine("[e] Alterar disponibilidade");
                            IOperacaoEstoque alterarDisponibilidade = new AlterarDisponibilidade();
                            alterarDisponibilidade.Executar(estoque);
                            break;

                        // opção [f] -> sair do programa
                        case 'f':
                            sairPrograma = SairProgramaOp();

                            break;

                        // opção default -> para entradas inesperadas
                        default:
                            Console.WriteLine("Opção inválida!" +
                                "\nPressione qualquer tecla para continuar!");
                            Console.ReadKey();
                            Console.Clear();

                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    Console.WriteLine("Pressione qualquer tecla para continuar!");
                    Console.ReadKey();
                    Console.Clear();

                }
            }
        }

        // metodo para finalizar o prgrama
        private static bool SairProgramaOp()
        {
            bool sairPrograma = false;
            try
            {
                Console.WriteLine("Deseja realmente sair do programa?");
                if (Console.ReadLine().ToLower()[0] == 's')
                {
                    Console.WriteLine("Finalizando programa...");
                    sairPrograma = true;
                }
                else
                    Console.WriteLine("Retornando ao programa...");

                Console.WriteLine("Pressione qualquer tecla para continuar!");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception e)
            { Console.WriteLine(e.Message); }
            return sairPrograma;

        }
    }
}