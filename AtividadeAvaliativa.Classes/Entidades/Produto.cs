namespace AtividadeAvaliativa.Classes.Entidades
{
    internal class Produto
    {
        // atributos
        private int codigo;
        private string? nome;
        private int qtdEstoque;
        private double precoUnitario;
        private bool disponibilidade;

        // construtores
        public Produto() { }
        public Produto(int codigo, string nome, int qtdEstoque, double precoUnitario, bool disponibilidade)
        {
            this.codigo = codigo;
            this.nome = nome;
            this.qtdEstoque = qtdEstoque;
            this.precoUnitario = precoUnitario;
            this.disponibilidade = disponibilidade;
        }

        // metodos
        public override string ToString()
        {
            return ($"Código: {this.codigo}, " +
                    $"Nome: {this.nome}, " +
                    $"Quantidade em estoque: {this.qtdEstoque}, " +
                    $"Preço unitário: R${this.precoUnitario:N2}");
        }

        // gets e sets
        public int Codigo { get => codigo; set => codigo = value; }
        public string? Nome { get => nome; set => nome = value; }
        public int QtdEstoque { get => qtdEstoque; set => qtdEstoque = value; }
        public double PrecoUnitario { get => precoUnitario; set => precoUnitario = value; }
        public bool Disponibilidade { get => disponibilidade; set => disponibilidade = value; }



    }
}
