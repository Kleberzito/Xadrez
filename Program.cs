using Tabuleiro;
using System;
using Chess;

namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Board Boa = new Board(8, 8);
                Boa.putPiece(new Tower(Boa, Color.Preto), new Position(0, 0));
                Boa.putPiece(new Tower(Boa, Color.Preto), new Position(1, 3));
                Boa.putPiece(new King(Boa, Color.Preto), new Position(7, 5));

                Screen.printScreen(Boa);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
