using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    public class BoardPositionGenerator
    {
        public Board GetEmptyBoard()
        {
            Board board = new Board();

            for (int rank = 1; rank <= 8; ++rank)
                for (int file = 1; file <= 8; ++file)
                    board.SetSquare(rank, file, PieceType.Empty, PieceColor.White);

            return board;
        }

        public Board GetNewGameStartingPosition()
        {
            Board board = new Board();

            board.SetPieceType(1, 1, PieceType.Rook);
            board.SetPieceType(1, 2, PieceType.Knight);
            board.SetPieceType(1, 3, PieceType.Bishop);
            board.SetPieceType(1, 4, PieceType.Queen);
            board.SetPieceType(1, 5, PieceType.King);
            board.SetPieceType(1, 6, PieceType.Bishop);
            board.SetPieceType(1, 7, PieceType.Knight);
            board.SetPieceType(1, 8, PieceType.Rook);

            for (int file = 1; file <= 8; ++file)
                board.SetPieceType(2, file, PieceType.Pawn);

            for (int rank = 1; rank <= 2; ++rank)
                for (int file = 1; file <= 8; ++file)
                    board.SetPieceColor(rank, file, PieceColor.White);

            // black is just mirroring the white position and changing the color

            for (int rank = 7; rank <= 8; ++rank)
                for (int file = 1; file <= 8; ++file)
                {
                    PieceType mirrorWhitePiece = board.GetPieceType((8 - rank) + 1, file);

                    board.SetPieceType(rank, file, mirrorWhitePiece);
                    board.SetPieceColor(rank, file, PieceColor.Black);
                }

            return board;
        }
    }
}
