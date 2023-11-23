using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    public class BoardPositionGenerator
    {
        public static Board GetEmptyBoard()
        {
            Board board = new Board();

            for (int rank = 1; rank <= 8; ++rank)
                for (int file = 1; file <= 8; ++file)
                    board.SetSquare(rank, file, PieceType.Empty, PieceColor.White);

            return board;
        }
    }
}
