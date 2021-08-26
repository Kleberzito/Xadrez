using Tabuleiro;
using System;
using Chess;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionChess p = new PositionChess(7, 'c');

            Console.WriteLine(p.toPosition());
            Console.WriteLine( p);

            Console.ReadLine();
        }
    }
}
