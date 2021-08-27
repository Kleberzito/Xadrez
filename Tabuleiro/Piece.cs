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

        public abstract bool[,] nMovimentPiece(); 

        public void PieceMoviment()
        {
            nMoving++;
        }
    }
}
