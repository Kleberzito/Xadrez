using System;
using System.Collections.Generic;
using Tabuleiro;
using Chess;

namespace Xadrez
{
    
    class Screen
    {
        public static void printMatch(ChessMatch match)
        {
            printScreen(match.boa);
            Console.WriteLine();
            printPiecesCatch(match);
            Console.WriteLine();
            Console.WriteLine("Turno: " + match.turn);
            if (!match.matchFinished)
            {
                Console.WriteLine("Aguadando jogada do jogador: " + match.currentPlayer);
                if (match.check)
                {
                    Console.WriteLine("EM XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUEMATE!!!");
                Console.WriteLine("Vitoria do jogardo: " + match.currentPlayer);
            }
        }

        public static void printPiecesCatch(ChessMatch match)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            printSet(match.piecesCaught(Color.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            printSet(match.piecesCaught(Color.Preto));
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> pieceSet)
        {
            Console.Write("[");
            foreach (Piece p in pieceSet)
            {                
                Console.Write(p + " ");
            }
            Console.Write("]");            
        }

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
            Console.WriteLine();
            Console.WriteLine("Legenda: ");
            Console.WriteLine("T = Torre, H = Cavalo, B = Bispo, Q = Rainha, K = Rei e P = Pinhão");

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
            Console.BackgroundColor = bOriginal;
        }

        public static PositionChess readPosition()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            if(linha < 8)
            {
                int n = 0;
                string l = coluna.ToString().ToLowerInvariant();

                switch (l)
                {                    
                    case "a": n = 0; break;
                    case "b": n = 1; break;
                    case "c": n = 2; break;
                    case "d": n = 3; break;
                    case "e": n = 4; break;
                    case "f": n = 5; break;
                    case "g": n = 6; break;
                    case "h": n = 7; break;
                }             

                if (n < 8)
                {                    
                    return new PositionChess(linha, char.ToLower(coluna));
                }
                else
                {
                    throw new BoardException("Posição fora do tabuleiro.");
                }
            }
            else
            {
                throw new BoardException("Posição fora do tabuleiro.");
            }
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
