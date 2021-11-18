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
        private HashSet<Piece> pieces;
        private HashSet<Piece> catchPiece;

        public ChessMatch()
        {
            boa = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            matchFinished = false;
            pieces = new HashSet<Piece>();
            catchPiece = new HashSet<Piece>();
            putPiece();
        }

        public HashSet<Piece> piecesCaught(Color cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach(Piece p in catchPiece)
            {
                if(p.Color == cor)
                {
                    aux.Add(p);
                }
            }

            return aux;
        }

        public HashSet<Piece> piecesInGame(Color cor)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in pieces)
            {
                if (p.Color == cor)
                {
                    aux.Add(p);
                }
            }

            aux.ExceptWith(piecesCaught(cor));

            return aux;
        }

        public void ExecuteMoviment(Position origin, Position destiny)
        {
            Piece p = boa.removePiece(origin);
            p.PieceMoviment();
            Piece capturedPiece = boa.removePiece(destiny);
            boa.putPiece(p, destiny);

            if(capturedPiece != null)
            {
                catchPiece.Add(capturedPiece);
            }
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

        public void TestPosDestiny(Position origin, Position destiny)
        {
            if (!boa.piece(origin).MoveTo(destiny))
            {
                throw new BoardException("Posição de destino inválida");
            }
        }

        public void putNewPiece(int line, char column, Piece piece)
        {
            boa.putPiece(piece, new PositionChess(line, column).toPosition());
            pieces.Add(piece);
        }

        public void putPiece()
        {
            putNewPiece(1, 'c', new Tower(boa, Color.Branca));
            putNewPiece(2, 'c', new Tower(boa, Color.Branca));
            putNewPiece(2, 'd', new Tower(boa, Color.Branca));
            putNewPiece(2, 'e', new Tower(boa, Color.Branca));
            putNewPiece(1, 'e', new Tower(boa, Color.Branca));
            putNewPiece(1, 'd', new King(boa, Color.Branca));

            putNewPiece(7, 'c', new Tower(boa, Color.Preto));
            putNewPiece(8, 'c', new Tower(boa, Color.Preto));
            putNewPiece(7, 'd', new Tower(boa, Color.Preto));
            putNewPiece(7, 'e', new Tower(boa, Color.Preto));
            putNewPiece(8, 'e', new Tower(boa, Color.Preto));
            putNewPiece(8, 'd', new King(boa, Color.Preto));
        }
    }
}
