using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.Quest02
{
    public class Quest02
    {
        private string? json;
        private DadosEstoque? dadosEstoque;
        
        public Quest02()
        {
            json = File.ReadAllText("Quest02\\Estoque.json");
            dadosEstoque = JsonSerializer.Deserialize<DadosEstoque>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        }

        public void BuscarEstoque()
        {

            Console.WriteLine();
            Console.WriteLine(" *--------------* ");
            Console.WriteLine("Lista de produtos");
            Console.WriteLine();


            foreach (Estoque item in dadosEstoque.estoque)
            {
                MostrarProduto(item);
                Console.WriteLine("-----------");
                Console.WriteLine();

            }

            Voltar();
        }


        public void Somar(Int32 codigoProduto, Int32 valor)
        {
            Estoque item = ProcurarItemPeloCodigo(codigoProduto);
            item.estoque += valor;
            AlterarDados(item);

        }

        public void Subtrair(Int32 codigoProduto, Int32 valor)
        {
            Estoque item = ProcurarItemPeloCodigo(codigoProduto);
            item.estoque -= valor;
            AlterarDados(item);
        }

        public void AlterarDados(Estoque item)
        {
            dadosEstoque.estoque[dadosEstoque.estoque.IndexOf(item)].estoque = item.estoque;

            string novoJson = JsonSerializer.Serialize(dadosEstoque, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Quest02\\Estoque.json", novoJson);
        }

        public Estoque ProcurarItemPeloCodigo(Int32 codProduto)
        {
            foreach (Estoque item in dadosEstoque.estoque)
            {
                if (item.codigoProduto == codProduto)
                {
                    return item;
                }
            }
            return null;
        }

        public void Entrada()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o código do produto");
            string? numero = Console.ReadLine();
            int.TryParse(numero , out Int32 codigo);
            Console.WriteLine();

            Console.WriteLine("Digite o valor a ser somado");
            string? valor = Console.ReadLine();
            int.TryParse(valor, out Int32 valorASerSomado);            
            Console.WriteLine();

            Somar(codigo, valorASerSomado);

            Estoque item = ProcurarItemPeloCodigo(codigo);

            Console.WriteLine("Produto alterado!");
            Console.WriteLine();

            MostrarProduto(item);

            Voltar();
                        
        }


        public void Saida()
        {
            Console.WriteLine();
            Console.WriteLine("Digite o código do produto");
            string? numero = Console.ReadLine();
            int.TryParse(numero, out Int32 codigo);
            Console.WriteLine();

            Console.WriteLine("Digite o valor a ser subtraido");
            string? valor = Console.ReadLine();
            int.TryParse(valor, out Int32 valorASerSomado);
            Console.WriteLine();

            Subtrair(codigo, valorASerSomado);

            Estoque item = ProcurarItemPeloCodigo(codigo);

            Console.WriteLine("Produto alterado!");
            Console.WriteLine();

            MostrarProduto(item);

            Voltar();


        }


        public void MostrarProduto(Estoque item)
        {
            Console.WriteLine("Código do produto:" + item.codigoProduto);
            Console.WriteLine();
            Console.WriteLine("Descrição:" + item.descricaoProduto);
            Console.WriteLine();
            Console.WriteLine("Quantidade em estoque:" + item.estoque);
            Console.WriteLine();
        }

        public void Voltar()
        {
            Console.WriteLine();
            Console.WriteLine("aperte qualquer tecla para voltar ao menu!");
            Console.ReadLine();
            Console.Clear();
            MovimentacaoEstoque();
        }


        public void MovimentacaoEstoque()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("bem vindo ao estoque!");
            Console.WriteLine(" ------------------ ");
            Console.WriteLine();
            Console.WriteLine("Selecione uma das opções");
            Console.WriteLine();
            Console.WriteLine("1 - Visualizar lista de produtos");
            Console.WriteLine("2 - Entrada de produtos");
            Console.WriteLine("3 - Saida de produtos");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":

                    BuscarEstoque();

                    break;
                case "2":

                    Entrada();

                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Comando inválido!");
                    break;

            }
        }

    }
}
