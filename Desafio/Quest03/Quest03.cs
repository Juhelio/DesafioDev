using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Quest03;
public class Quest03
{


    public void Calcaculadora()
    {
        Console.WriteLine("Calculadora de Juros");
        Console.WriteLine("*------------------*");
        Console.WriteLine();

        Console.Write("Digite o valor da dívida: R$ "); 
        float valor = float.Parse(Console.ReadLine(), CultureInfo.GetCultureInfo("pt-BR"));
        Console.WriteLine();

        Console.Write("Digite a data de vencimento (dd/MM/yyyy): "); 
        DateTime vencimento = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
        Console.WriteLine();


        DateTime hoje = DateTime.Today;


        if (hoje <= vencimento)
        {
            Console.WriteLine();
            Console.WriteLine("A dívida não está atrasada.");
            Console.WriteLine($"Valor: R$ {valor:F2}");
            return;
        }

        int diasAtraso = (hoje - vencimento).Days;

        float taxaDiaria = 0.025f;

        float juros = valor * taxaDiaria * diasAtraso;

        float valorTotal = valor + juros;

        Console.WriteLine();
        Console.WriteLine("*---- Resultado ----*");
        Console.WriteLine($"Valor original: R$ {valor:F2}");
        Console.WriteLine($"Data de vencimento: {vencimento:dd/MM/yyyy}");
        Console.WriteLine($"Data atual: {hoje:dd/MM/yyyy}");
        Console.WriteLine($"Dias de atraso: {diasAtraso}");
        Console.WriteLine($"Taxa de juros: 2,5% ao dia");
        Console.WriteLine($"Juros: R$ {juros:F2}");
        Console.WriteLine($"Valor total: R$ {valorTotal:F2}");

        Console.WriteLine(); 
        Console.WriteLine("Pressione qualquer tecla para sair..."); 
        Console.ReadKey();


    }

}
