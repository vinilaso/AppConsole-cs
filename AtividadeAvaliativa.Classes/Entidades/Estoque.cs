namespace AtividadeAvaliativa.Classes.Entidades
{

    internal class Estoque
    {
        // atributo + get
        private List<Produto> produtos = new List<Produto>();


        // construtores
        public Estoque() { }

        // metodos

        // verifica se um determinado código está disponível
        public bool CodigoDisponivel(int codigo)
        {
            return !produtos.Any(produto =>  produto.Codigo == codigo);
        }

        // retorna um produto de acordo com seu código
        public Produto? ConsultarProduto(int codigo)
        {
            Produto? query = null;
            if (produtos.Count == 0)
                return query;

            query = produtos.FirstOrDefault(produto => produto.Codigo == codigo);

            if (query == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Código não cadastrado!");
                Console.ResetColor();
            }
            return query;
        }

        // retorna um produto de acordo com seu código, se estiver disponível
        public Produto? ConsultarProdutoDisponivel(int codigo)
        {
            Produto? query = ConsultarProduto(codigo);
            if (query == null) return null;
            else if (query.Disponibilidade) return query;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Produto indisponível!");
                Console.ResetColor();
                return null;
            }
        }

        // lista todos os produtos contidos em estoque
        public List<Produto> ListarProdutos()
        {
            List<Produto> lista = produtos.Where(produto => produto.Disponibilidade == true).ToList();
            if(produtos.Count != 0 && lista.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum produto disponível em estoque!");
                Console.ResetColor();
                return lista;
            }
            if (lista.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum produto no estoque!");
                Console.ResetColor();
            }
            return lista;
        }

        // atualiza a quantidade de determinado produto presente no estoque, se disponível
        public void AtualizarEstoque(int codigo, int quantidade)
        {
            Produto? query = ConsultarProdutoDisponivel(codigo);
            if (query == null) { return; }
            else
            {
                query.QtdEstoque = quantidade;
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("Quantidade em estoque alterada com sucesso!");
                Console.ResetColor();
            }
        }

        // altera a disponibilidade de determinado produto
        public void AlterarDisponibilidade(int codigo, bool disponibilidade)
        {
            Produto? query = ConsultarProduto(codigo);
            if (query == null) return;
            else
            {
                query.Disponibilidade = disponibilidade;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Disponibilidade alterada com sucesso!");
                Console.ResetColor();
            }
        }

        // adiciona produtos no estoque, se este não estiver cheio
        public void AdicionarProduto(Produto produto)
        {
            if (EstoqueCheio())
                return;
            else if (CodigoDisponivel(produto.Codigo))
            {
                produtos.Add(produto);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Produto cadastrado com sucesso!");
                Console.ResetColor();
            }
        }

        // verifica se o estoque possui mais de 10 produtos
        public bool EstoqueCheio()
        {
            return (produtos.Count >= 10);
        }

        // verifica se há produtos cadastrados
        public bool TemProdutosCadastrados()
        {
            if (produtos.Count != 0)
                return true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Nenhum produto cadastrado!");
            Console.ResetColor();
            return false;
        }
    }
}
