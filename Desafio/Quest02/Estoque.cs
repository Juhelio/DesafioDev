using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Quest02
{
    public class Estoque
    {
        public Int32 codigoProduto {  get; set; }
        public string? descricaoProduto { get; set; }
        public Int32 estoque {  get; set; } 
    }
    public class DadosEstoque
    {
        public List<Estoque>? estoque { get; set; }
    }
}
