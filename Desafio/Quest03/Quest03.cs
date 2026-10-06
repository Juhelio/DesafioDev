using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio.Quest03;
public class Quest03
{

    public delegate void Quest03Delegate();

    public event Quest03Delegate OnMenssage;


    public void Calculadora()
    {
        

        Console.Write("Digite o valor da dívida: R$ ");
        if (!float.TryParse(Console.ReadLine(), CultureInfo.GetCultureInfo("pt-BR"), out float valor))
        {
            Console.WriteLine("Valor não numérico! Pressione qualquer tecla para um novo lançamento");
            Console.ReadLine();
            Console.Clear();
            Calculadora();
        }
        Console.WriteLine();

        Console.Write("Digite a data de vencimento (dd/MM/yyyy): ");
        if(!DateTime.TryParseExact(Console.ReadLine(),  "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime vencimento))
        {
            Console.WriteLine("Data inválida! Pressione qualquer tecla para um novo lançamento");
            Console.ReadLine();
            Console.Clear();
            Calculadora();

        }
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
        Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
        Console.ReadKey();
        Console.Clear();
        MenuCalculo();

    }

    public void MenuCalculo()
    {
        Console.WriteLine("Calculadora de Juros");
        Console.WriteLine("*------------------*");
        Console.WriteLine();

        Console.WriteLine("1 - Calcular divida");
        Console.WriteLine("2 - Voltar ao menu dos desafios");
        string? command = Console.ReadLine();

        switch (command)
        {
            case "1":
                Console.Clear();
                Calculadora();
                break;
            case "2":
                Console.Clear();
                OnMenssage?.Invoke();
                break;
            default:
                Console.WriteLine("Nenhum comando válido! Pressione qualquer tecla.");
                Console.ReadLine();
                Console.Clear();
                Calculadora();
                break;
        }
    }

}
