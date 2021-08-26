using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    class Board
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Piece[,] Piece;
        
        public Board(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
        }
    }
}
