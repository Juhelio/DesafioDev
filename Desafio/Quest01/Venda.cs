using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Quest01
{
    public class Venda
    {
        public string? Vendedor { get; set; }
        public double Valor { get; set; }
    }

    public class DadosVendas
    {
        public List<Venda>? Vendas { get; set; }
    }
}
