using System;
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

        public Piece piece(int linha, int coluna)
        {
            return Pieces[linha, coluna];
        }

        public Piece piece(Position pos)
        {
            return Pieces[pos.Linha, pos.Coluna];
        }

        public void putPiece(Piece p, Position pos)
        {
            if (existsPiece(pos))
            {
                throw new BoardException("Posição ja ocupada por outra peça");
            }
            Pieces[pos.Linha, pos.Coluna] = p;
            p.Position = pos;
        }

        public bool existsPiece(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public bool validPosition(Position pos)
        {
            if (pos.Linha < 0 || pos.Linha>=Linhas || pos.Coluna<0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Posição inveliada");
            }
        }
    }
}
