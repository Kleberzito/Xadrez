using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Chess
{
    class ChessMatch
    {
        public Board boa { get; private set; }
        public int turn { get; private set; }
        public Color currentPlayer { get; private set; }
        public bool matchFinished { get; private set; }

        public ChessMatch()
        {
            boa = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            putPiece();
        }

        public void ExecuteMoviment(Position origin, Position destiny)
        {
            Piece p = boa.removePiece(origin);
            p.PieceMoviment();
            Piece capturedPiece = boa.removePiece(destiny);
            boa.putPiece(p, destiny);
        }

        public void TurnPlaying(Position origin, Position destiny)
        {
            ExecuteMoviment(origin, destiny);
            turn++;
            if(currentPlayer == Color.Branca)
            {
                currentPlayer = Color.Preto;
            }
            else
            {
                currentPlayer = Color.Branca;
            }
        }

        public void TestPosOrigin(Position pos)
        {
            if (boa.piece(pos) == null)
            {
                throw new BoardException("Não existe peça na posição escolhida");
            }

            if(currentPlayer != boa.piece(pos).Color)
            {
                throw new BoardException("Peça de escolhida não é sua");
            }

            if (!boa.piece(pos).existsMovement())
            {
                throw new BoardException("Não existe jogadas para a esta peça");
            }
        }

        public void putPiece()
        {
            boa.putPiece(new Tower(boa, Color.Branca), new PositionChess(1, 'c').toPosition());
            boa.putPiece(new Tower(boa, Color.Branca), new PositionChess(2, 'c').toPosition());
            boa.putPiece(new Tower(boa, Color.Branca), new PositionChess(2, 'd').toPosition());
            boa.putPiece(new Tower(boa, Color.Branca), new PositionChess(2, 'e').toPosition());
            boa.putPiece(new Tower(boa, Color.Branca), new PositionChess(1, 'e').toPosition());
            boa.putPiece(new King(boa, Color.Branca), new PositionChess(1, 'd').toPosition());

            boa.putPiece(new Tower(boa, Color.Preto), new PositionChess(7, 'c').toPosition());
            boa.putPiece(new Tower(boa, Color.Preto), new PositionChess(8, 'c').toPosition());
            boa.putPiece(new Tower(boa, Color.Preto), new PositionChess(7, 'd').toPosition());
            boa.putPiece(new Tower(boa, Color.Preto), new PositionChess(7, 'e').toPosition());
            boa.putPiece(new Tower(boa, Color.Preto), new PositionChess(8, 'e').toPosition());
            boa.putPiece(new King(boa, Color.Preto), new PositionChess(8, 'd').toPosition());

        }
    }
}
