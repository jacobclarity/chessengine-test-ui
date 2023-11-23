using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    public class MutableSquareData : ISquareData
    {
        public PieceType PieceType { get; set; }
        public PieceColor PieceColor { get; set; }

        public MutableSquareData() { }

        public MutableSquareData(PieceType pieceType, PieceColor pieceColor)
        {
            PieceType = pieceType;
            PieceColor = pieceColor;
        }

        public MutableSquareData(ISquareData other)
        {
            PieceType = other.PieceType;
            PieceColor = other.PieceColor;
        }

        public static readonly ISquareData EmptySquare = new MutableSquareData(PieceType.Empty, PieceColor.White);
    }

    public interface ISquareData
    {
        PieceType PieceType { get; }
        PieceColor PieceColor { get; }
    }
}
