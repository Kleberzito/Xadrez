using Tabuleiro;
using System;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            Board Boa = new Board(8, 8);
            Screen.printScreen(Boa);

            Console.ReadLine();
        }
    }
}
