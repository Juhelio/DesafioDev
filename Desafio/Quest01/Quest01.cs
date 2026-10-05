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


        public void Resultado()
        {
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
        }

    }
}
