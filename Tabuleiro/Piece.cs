using System;
using System.Collections.Generic;
using System.Text;

namespace Tabuleiro
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int nMoving { get; protected set; }
        public Board Board { get; protected set; }

        public Piece(Color color, Board board)
        {
            Position = null;
            Color = color;
            Board = board;
            nMoving = 0;
        }

        public bool existsMovement()
        {
            bool[,] mat = nMovimentPiece();
            for(int l = 0; l < Board.Linhas; l++)
            {
                for (int c = 0; c < Board.Colunas; c++)
                {
                    if(mat[l, c])
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool MoveTo(Position pos)
        {
            return nMovimentPiece()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] nMovimentPiece(); 

        public void PieceMoviment()
        {
            nMoving++;
        }
        public void PieceMovimentUndo()
        {
            nMoving--;
        }
    }
}
