using System;
using Desafio.Quest01;
using Desafio.Quest02;
using Desafio.Quest03;



public class Program
{
    static void Main()
    {

        Quest01 quest01 = new Quest01();
        Quest02 quest02 = new Quest02();
        Quest03 quest03 = new Quest03();

        quest01.OnMenssage += MenuInicial;
        quest02.OnMenssage += MenuInicial;
        quest03.OnMenssage += MenuInicial;

        MenuInicial();
       
        void MenuInicial()
        {
            Console.WriteLine("Bem vindo ao Desafio Dev");
            Console.WriteLine("*----------------------*");
            Console.WriteLine();
            Console.WriteLine("Escolha um desafio:");
            Console.WriteLine(" 1 - Desafio 01");
            Console.WriteLine(" 2 - Desafio 02");
            Console.WriteLine(" 3 - Desafio 03");


            string? quest = Console.ReadLine();
            

            switch (quest)
            {
                case "1":
                    Console.Clear();
                    quest01.Resultado();
                    break;
                case "2":
                    Console.Clear();
                    quest02.MovimentacaoEstoque();
                    break;
                case "3":
                    Console.Clear();
                    quest03.MenuCalculo();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Escolha uma opção válida!");
                    Console.WriteLine();
                    MenuInicial();
                    break;

            }
        }
    }
}
