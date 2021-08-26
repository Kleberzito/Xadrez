using System;
using System.Collections.Generic;
using System.Text;
using Tabuleiro;

namespace Chess
{
    class Tower : Piece
    {
        public Tower(Board boa, Color color) : base(color, boa)
        {

        }

        public override string ToString()
        {
            return "T";
        }

    }
}
