using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Chess
{
    class King : Piece
    {
        public King(Board boa, Color color) : base(color, boa)
        {

        }

        public override string ToString()
        {
            return "K";
        }

    }
}
