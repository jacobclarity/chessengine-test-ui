using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    public class SquarePosition
    {
        public int Rank { get; }
        public int File { get; }

        public SquarePosition(int rank, int file)
        {
            this.Rank = rank;
            this.File = file;
        }
    }
}
