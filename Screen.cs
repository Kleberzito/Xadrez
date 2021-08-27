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
                    if(boa.piece(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        printPiece(boa.piece(l, c));
                        Console.Write(" ");
                    }
                    
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

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
            if(piece.Color == Color.Branca)
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
        }

    }
}
