using System;

using Desafio.Quest01;
using Desafio.Quest02;
using Desafio.Quest03;



public class Program
{
    delegate void Menu();

    static void Main()
    {

        Quest01 quest01 = new Quest01();
        Quest02 quest02 = new Quest02();
        Quest03 quest03 = new Quest03();


        quest01.Menu()

        quest01.Resultado();



        //quest02.MovimentacaoEstoque();
        //quest03.Calcaculadora();

        //Console.WriteLine(quest02.GetNewNumber());



    }



    void MenuInicial()
    {

    }
}
