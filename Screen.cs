using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Xadrez
{
    class Screen
    {
        public static void printScreen(Board boa)
        {
            for(int l = 0; l < boa.Linhas; l++)
            {
                for(int c = 0; c < boa.Colunas; c++)
                {
                    if(boa.piece(l, c) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(boa.piece(l, c) + " ");
                    }
                    
                }
                Console.WriteLine();
            }

        }

    }
}
