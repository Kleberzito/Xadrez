using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Chess
{
    class Pawn : Piece
    {
        public Pawn(Board boa, Color color) : base(color, boa)
        {

        }

        public override string ToString()
        {
            return "P";
        }

        private bool existEnimy(Position pos)
        {
            Piece p = Board.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool Free(Position pos)
        {
            return Board.piece(pos) == null;
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

            if(Color == Color.Branca)
            {
                pos.definePosition(Position.Linha - 1, Position.Coluna);
                if(Board.validPosition(pos) && Free(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definePosition(Position.Linha - 2, Position.Coluna);
                if (Board.validPosition(pos) && Free(pos) && nMoving == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definePosition(Position.Linha - 1, Position.Coluna - 1);
                if (Board.validPosition(pos) && existEnimy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definePosition(Position.Linha - 1, Position.Coluna + 1);
                if (Board.validPosition(pos) && existEnimy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.definePosition(Position.Linha + 1, Position.Coluna);
                if (Board.validPosition(pos) && Free(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definePosition(Position.Linha + 2, Position.Coluna);
                if (Board.validPosition(pos) && Free(pos) && nMoving == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definePosition(Position.Linha + 1, Position.Coluna - 1);
                if (Board.validPosition(pos) && existEnimy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
                pos.definePosition(Position.Linha + 1, Position.Coluna + 1);
                if (Board.validPosition(pos) && existEnimy(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }

            return mat;
        }

    }
}


