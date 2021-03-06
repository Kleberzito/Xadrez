using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Chess
{
    class Knight : Piece
    {
        public Knight(Board boa, Color color) : base(color, boa)
        {

        }

        public override string ToString()
        {
            return "H";
        }

        private bool Move(Position pos)
        {
            Piece p = Board.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] nMovimentPiece()
        {
            bool[,] mat = new bool[Board.Linhas, Board.Colunas];

            Position pos = new Position(0, 0);

            pos.definePosition(Position.Linha - 1, Position.Coluna - 2);
            if(Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definePosition(Position.Linha - 2, Position.Coluna - 1);
            if (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definePosition(Position.Linha - 2, Position.Coluna + 1);
            if (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definePosition(Position.Linha - 1, Position.Coluna + 2);
            if (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definePosition(Position.Linha + 1, Position.Coluna + 2);
            if (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definePosition(Position.Linha + 2, Position.Coluna + 1);
            if (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definePosition(Position.Linha + 2, Position.Coluna - 1);
            if (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            pos.definePosition(Position.Linha + 1, Position.Coluna - 2);
            if (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
            }

            return mat;
        }

    }
}

