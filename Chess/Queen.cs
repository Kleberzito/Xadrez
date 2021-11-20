using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Chess
{
    class Queen : Piece
    {
        public Queen(Board boa, Color color) : base(color, boa)
        {

        }

        public override string ToString()
        {
            return "Q";
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

            pos.definePosition(Position.Linha + 1, Position.Coluna);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            pos.definePosition(Position.Linha - 1, Position.Coluna);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            pos.definePosition(Position.Linha, Position.Coluna + 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }
            pos.definePosition(Position.Linha, Position.Coluna - 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            pos.definePosition(Position.Linha - 1, Position.Coluna - 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(Position.Linha - 1, Position.Coluna - 1);
            }

            pos.definePosition(Position.Linha - 1, Position.Coluna + 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(Position.Linha - 1, Position.Coluna + 1);
            }

            pos.definePosition(Position.Linha + 1, Position.Coluna + 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(Position.Linha + 1, Position.Coluna + 1);
            }

            pos.definePosition(Position.Linha + 1, Position.Coluna - 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(Position.Linha + 1, Position.Coluna - 1);
            }

            return mat;
        }

    }
}

