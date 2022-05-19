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
                ChessMatch match = new ChessMatch();

                while (!match.matchFinished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origem (Letra + Número): ");
                        Position origin = Screen.readPosition().toPosition();
                        match.TestPosOrigin(origin);

                        bool[,] move = match.boa.piece(origin).nMovimentPiece();
                        Console.Clear();
                        Screen.printScreen(match.boa, move);

                        Console.WriteLine();
                        Console.Write("Destino(Letra + Número): ");
                        Position destiny = Screen.readPosition().toPosition();
                        match.TestPosDestiny(origin, destiny);

                        match.TurnPlaying(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Pressione Enter.");
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.printMatch(match);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
