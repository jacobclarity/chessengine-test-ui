using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    public class Board : IBoard
    {
        private MutableSquareData[] _squares;

        public Board()
        {
            _squares = new MutableSquareData[64];

            for (int i = 0; i < _squares.Length; ++i)
                _squares[i] = new MutableSquareData(PieceType.Empty, PieceColor.White);
        }

        public Board(Board other)
        {
            _squares = new MutableSquareData[64];

            CopyBoard(other);
        }

        public void CopyBoard(Board other)
        {
            for (int i = 0; i < _squares.Length; ++i)
                _squares[i] = new MutableSquareData(other._squares[i]);
        }

        // rank 1-8, file 1-8
        private int MapPositionToArray(int rank, int file)
        {
            if (rank < 1 || rank > 8 || file < 1 || file > 8)
                throw new Exception($"rank and file must be in [1, 8]; invalid coordinates rank={rank}, file={file}");

            return (rank - 1) * 8 + (file - 1);
        }

        public ISquareData GetSquare(int rank, int file)
        {
            return _squares[MapPositionToArray(rank, file)];
        }

        public PieceType GetPieceType(int rank, int file)
        {
            return _squares[MapPositionToArray(rank, file)].PieceType;
        }


        public PieceColor GetPieceColor(int rank, int file)
        {
            return _squares[MapPositionToArray(rank, file)].PieceColor;
        }

        public void SetSquare(int rank, int file, ISquareData square)
        {
            _squares[MapPositionToArray(rank, file)] = new MutableSquareData(square);
        }

        public void SetSquare(int rank, int file, PieceType pieceType, PieceColor pieceColor)
        {
            int arrayIndex = MapPositionToArray(rank, file);

            _squares[arrayIndex].PieceType = pieceType;
            _squares[arrayIndex].PieceColor = pieceColor;
        }

        public void SetPieceType(int rank, int file, PieceType pieceType)
        {

            _squares[MapPositionToArray(rank, file)].PieceType = pieceType;
        }

        public void SetPieceColor(int rank, int file, PieceColor pieceColor)
        {
            _squares[MapPositionToArray(rank, file)].PieceColor = pieceColor;
        }

    }

    public interface IBoard
    {
        ISquareData GetSquare(int rank, int file);
        PieceType GetPieceType(int rank, int file);
        PieceColor GetPieceColor(int rank, int file);
    }
}
