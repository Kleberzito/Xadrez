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
                        Screen.printScreen(match.boa);
                        Console.WriteLine("Turno: " + match.turn);
                        Console.WriteLine("Aguadando jogada do jogador: " + match.currentPlayer);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Position origin = Screen.readPosition().toPosition();
                        match.TestPosOrigin(origin);

                        bool[,] move = match.boa.piece(origin).nMovimentPiece();
                        Console.Clear();
                        Screen.printScreen(match.boa, move);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Position destiny = Screen.readPosition().toPosition();

                        match.TurnPlaying(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Screen.printScreen(match.boa);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
