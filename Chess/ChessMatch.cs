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
        public bool check { get; private set; }

        public ChessMatch()
        {
            boa = new Board(8, 8);
            turn = 1;
            currentPlayer = Color.Branca;
            matchFinished = false;
            check = false;
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

        private Color adversary(Color cor)
        {
            if(cor == Color.Branca)
            {
                return Color.Preto;
            }
            else
            {
                return Color.Branca;
            }
        }

        private Piece king(Color cor)
        {
            foreach(Piece p in piecesInGame(cor))
            {
                if( p is King) { return p;}
            }
            return null;
        }

        public bool inCheck(Color cor)
        {
            Piece k = king(cor);
            if(k == null)
            {
                throw new BoardException("Não tem a peça Rei " + cor + "no tabuleiro");
            }

            foreach(Piece p in piecesInGame(adversary(cor)))
            {
                bool[,] mat = p.nMovimentPiece();
                if (mat[k.Position.Linha, k.Position.Coluna])
                {
                    return true;
                }                
            }

            return false;
        }

        public bool testCheckmate(Color cor)
        {
            if (!inCheck(cor))
            {
                return false;
            }

            foreach(Piece p in piecesInGame(cor))
            {
                bool[,] mat = p.nMovimentPiece();
                for(int l = 0; l < boa.Linhas; l++)
                {
                    for (int c = 0; c < boa.Colunas; c++)
                    {
                        if(mat[l, c])
                        {
                            Position origin = p.Position;
                            Position desteny = new Position(l, c);
                            Piece capturedPiece = ExecuteMoviment(origin, desteny);
                            bool testCheck = inCheck(cor);
                            undoMoviment(origin, desteny, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public Piece ExecuteMoviment(Position origin, Position destiny)
        {
            Piece p = boa.removePiece(origin);
            p.PieceMoviment();
            Piece capturedPiece = boa.removePiece(destiny);
            boa.putPiece(p, destiny);

            if(capturedPiece != null)
            {
                catchPiece.Add(capturedPiece);
            }

            return capturedPiece;
        }

        public void undoMoviment(Position origin, Position destiny, Piece capturedPiece)
        {
            Piece p = boa.removePiece(destiny);
            p.PieceMovimentUndo();
            
            if(capturedPiece != null)
            {
                boa.putPiece(capturedPiece, destiny);
                catchPiece.Remove(capturedPiece);
            }

            boa.putPiece(p, origin);
        }

        public void TurnPlaying(Position origin, Position destiny)
        {
            Piece capturedPiece = ExecuteMoviment(origin, destiny);

            if (inCheck(currentPlayer))
            {
                undoMoviment(origin, destiny, capturedPiece);
                throw new BoardException("Rei em Xeque");
            }

            if (inCheck(adversary(currentPlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }

            if (testCheckmate(adversary(currentPlayer)))
            {
                matchFinished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }            
        }

        private void changePlayer()
        {
            if (currentPlayer == Color.Branca)
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
            putNewPiece(1, 'a', new Tower(boa, Color.Branca));
            putNewPiece(1, 'b', new Knight(boa, Color.Branca));
            putNewPiece(1, 'c', new Bishop(boa, Color.Branca));
            putNewPiece(1, 'd', new Queen(boa, Color.Branca));
            putNewPiece(1, 'e', new King(boa, Color.Branca));
            putNewPiece(1, 'f', new Bishop(boa, Color.Branca));
            putNewPiece(1, 'g', new Knight(boa, Color.Branca));
            putNewPiece(1, 'h', new Tower(boa, Color.Branca));
            putNewPiece(2, 'a', new Pawn(boa, Color.Branca));
            putNewPiece(2, 'b', new Pawn(boa, Color.Branca));
            putNewPiece(2, 'c', new Pawn(boa, Color.Branca));
            putNewPiece(2, 'd', new Pawn(boa, Color.Branca));
            putNewPiece(2, 'e', new Pawn(boa, Color.Branca));
            putNewPiece(2, 'f', new Pawn(boa, Color.Branca));
            putNewPiece(2, 'g', new Pawn(boa, Color.Branca));
            putNewPiece(2, 'h', new Pawn(boa, Color.Branca));

            putNewPiece(8, 'a', new Tower(boa, Color.Preto));
            putNewPiece(8, 'b', new Knight(boa, Color.Preto));
            putNewPiece(8, 'c', new Bishop(boa, Color.Preto));
            putNewPiece(8, 'd', new Queen(boa, Color.Preto));
            putNewPiece(8, 'e', new King(boa, Color.Preto));
            putNewPiece(8, 'f', new Bishop(boa, Color.Preto));
            putNewPiece(8, 'g', new Knight(boa, Color.Preto));
            putNewPiece(8, 'h', new Tower(boa, Color.Preto));
            putNewPiece(7, 'a', new Pawn(boa, Color.Preto));
            putNewPiece(7, 'b', new Pawn(boa, Color.Preto));
            putNewPiece(7, 'c', new Pawn(boa, Color.Preto));
            putNewPiece(7, 'd', new Pawn(boa, Color.Preto));
            putNewPiece(7, 'e', new Pawn(boa, Color.Preto));
            putNewPiece(7, 'f', new Pawn(boa, Color.Preto));
            putNewPiece(7, 'g', new Pawn(boa, Color.Preto));
            putNewPiece(7, 'h', new Pawn(boa, Color.Preto));
            


            
        }
    }
}
