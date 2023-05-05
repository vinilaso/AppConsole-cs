using AtividadeAvaliativa.Classes.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeAvaliativa.Classes.Util
{
    internal interface IOperacaoEstoque
    {
        void Executar(Estoque estoque);
        void Sair();
    }
}
