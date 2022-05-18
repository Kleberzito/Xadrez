using Tabuleiro;

namespace Chess
{
    class Bishop : Piece
    {
        public Bishop(Board boa, Color color) : base(color, boa)
        {

        }

        public override string ToString()
        {
            return "B";
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

            pos.definePosition(Position.Linha - 1, Position.Coluna - 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(pos.Linha - 1, pos.Coluna - 1);
            }

            pos.definePosition(Position.Linha - 1, Position.Coluna + 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(pos.Linha - 1, pos.Coluna + 1);
            }

            pos.definePosition(Position.Linha + 1, Position.Coluna + 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(pos.Linha + 1, pos.Coluna + 1);
            }

            pos.definePosition(Position.Linha + 1, Position.Coluna - 1);
            while (Board.validPosition(pos) && Move(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Board.piece(pos) != null && Board.piece(pos).Color != Color)
                {
                    break;
                }
                pos.definePosition(pos.Linha + 1, pos.Coluna - 1);
            }


            return mat;
        }

    }
}

