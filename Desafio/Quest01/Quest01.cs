using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.Quest01
{

    public class Quest01
    {
        private string? json;

        public delegate void Quest01Delegate();

        public event Quest01Delegate OnMenssage;

        public void Resultado()
        {
            Console.WriteLine("Comissão dos vendedores");
            Console.WriteLine("*---------------------*");
            Console.WriteLine();

            json = File.ReadAllText("Quest01\\Vendas.json");

            DadosVendas? dados = JsonSerializer.Deserialize<DadosVendas>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (dados == null) return;

            foreach (Venda item in dados.Vendas)
            {
                Console.WriteLine(item.Vendedor + " = " + item.Valor);

                if (item.Valor >= 100)
                {
                    double comissao = item.Valor < 500 ? 1 : 5;

                    double calculoComissao = Math.Round(item.Valor * (comissao / 100), 2);

                    Console.WriteLine("Comissão de " + comissao + "% = " + calculoComissao);
                }

                Console.WriteLine();
            }
            Console.WriteLine("Aperte qualquer tecla para voltar ao menu dos desafios.");
            Console.ReadLine();
            Console.Clear();
            OnMenssage?.Invoke();
        }


    }
}
