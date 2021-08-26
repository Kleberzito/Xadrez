﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    class Board
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Piece[,] Pieces;
        
        public Board(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pieces = new Piece[linhas, colunas];
        }

        public Piece piece( int linha, int coluna)
        {
            return Pieces[linha, coluna];
        }

        public void putPiece(Piece p, Position pos)
        {
            Pieces[pos.Linha, pos.Coluna] = p;
            p.Position = pos;
        }
    }
}
