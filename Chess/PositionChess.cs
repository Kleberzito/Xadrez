using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Chess
{
    class PositionChess
    {
        public int Linha { get; set; }
        public char Coluna { get; set; }

        public PositionChess(int linha, char coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public Position toPosition()
        {
            return new Position(8 - Linha, Coluna - 'a');
        }

        public override string ToString()
        {
            return Coluna.ToString().ToUpper() + Linha;
        }
    }
}
