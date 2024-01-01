using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    public class GameState
    {
        public PieceColor PlayerTurnColor { get; }
        public CastlingAvailability WhiteCastlingAbility { get; }
        public CastlingAvailability BlackCastlingAbility { get; }

        public readonly SquarePosition? EnPassantTargetSquare;

        public int HalfMoveCounterFor50MoveDraw { get; }
        public int FullMoveCounter { get; }

        public GameState(PieceColor playerTurnColor, CastlingAvailability whiteCastlingAbility, CastlingAvailability blackCastlingAbility, SquarePosition? enPassantTargetSquare, int halfMoveCounterFor50MoveDraw, int fullMoveCounter)
        {
            PlayerTurnColor = playerTurnColor;
            WhiteCastlingAbility = whiteCastlingAbility;
            BlackCastlingAbility = blackCastlingAbility;
            EnPassantTargetSquare = enPassantTargetSquare;
            HalfMoveCounterFor50MoveDraw = halfMoveCounterFor50MoveDraw;
            FullMoveCounter = fullMoveCounter;
        }
    }
}
