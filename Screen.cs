using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;
using Chess;

namespace Xadrez
{
    class Screen
    {
        public static void printScreen(Board boa)
        {
            for(int l = 0; l < boa.Linhas; l++)
            {
                Console.Write(8 - l + " ");
                for(int c = 0; c < boa.Colunas; c++)
                {
                    printPiece(boa.piece(l, c));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

        }

        public static void printScreen(Board boa, bool[,] move)
        {
            ConsoleColor bOriginal = Console.BackgroundColor;
            ConsoleColor bNew = ConsoleColor.DarkGray;

            for (int l = 0; l < boa.Linhas; l++)
            {
                Console.Write(8 - l + " ");
                for (int c = 0; c < boa.Colunas; c++)
                {
                    if (move[l, c])
                    {
                        Console.BackgroundColor = bNew;
                    }
                    else
                    {
                        Console.BackgroundColor = bOriginal;
                    }
                    printPiece(boa.piece(l, c));
                    Console.BackgroundColor = bOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = bOriginal;

        }

        public static PositionChess readPosition()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PositionChess(linha, coluna);
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.Branca)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }            
        }

    }
}
