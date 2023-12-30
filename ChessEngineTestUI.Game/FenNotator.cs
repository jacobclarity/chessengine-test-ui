using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    internal class FenNotator
    {
        public string GetFenStringForPosition(BoardAndGameState state)
        {
            StringBuilder builder = new StringBuilder();

            for (int rank = 8; rank >= 0; --rank)
            {
                AppendRankString(builder, state.Board, rank);
            }

            // append state stuff

            return builder.ToString();
        }

        private void AppendRankString(StringBuilder builder, IBoard board, int rank)
        {
            AlgebraicNotation alNotator = new AlgebraicNotation();

            int emptySquareCounter = 0;

            for (int file = 1; file <= 8; ++file)
            {
                ISquareData piece = board.GetSquare(rank, file);

                if (piece.PieceType == PieceType.Empty)
                {
                    ++emptySquareCounter;

                    continue;
                }
                else
                {
                    if (emptySquareCounter > 0)
                    {
                        builder.Append(emptySquareCounter);

                        emptySquareCounter = 0;
                    }

                    char pieceLetter = alNotator.GetPieceLetterForPieceAndColor(piece.PieceType, piece.PieceColor);

                    builder.Append(pieceLetter);
                }
            }

            if (emptySquareCounter > 0)
                builder.Append(emptySquareCounter);
        }

        private void AppendGameStateString(StringBuilder builder, GameState state)
        {
            // active color
            if (state.PlayerTurnColor == PieceColor.White)
                builder.Append('w');
            else
                builder.Append('b');

            // castling availability
            // list white, then black. White can be K, Q, or KQ. Black can be k, q, or kq.
            // if a side has no castling options, there are no letters. If neither side has castling options,
            // use "-"
            bool emptyCastlingAbility = !(state.WhiteCastlingAbility.CanCastleKingside() || state.WhiteCastlingAbility.CanCastleQueenside()
                                       || state.BlackCastlingAbility.CanCastleKingside() || state.BlackCastlingAbility.CanCastleQueenside());

            if (emptyCastlingAbility)
                builder.Append("-");
            else
            {
                if (state.WhiteCastlingAbility == CastlingAvailability.Both)
                    builder.Append("KQ");
                else if (state.WhiteCastlingAbility == CastlingAvailability.Kingside)
                    builder.Append("K");
                else if (state.WhiteCastlingAbility == CastlingAvailability.Queenside)
                    builder.Append("Q");

                if (state.BlackCastlingAbility == CastlingAvailability.Both)
                    builder.Append("kq");
                else if (state.BlackCastlingAbility == CastlingAvailability.Kingside)
                    builder.Append("k");
                else if (state.BlackCastlingAbility == CastlingAvailability.Queenside)
                    builder.Append("q");
            }

            // en passant target square
            if (state.EnPassantTargetSquare is null)
                builder.Append("-");
            else
            {
                AlgebraicNotation alNotator = new AlgebraicNotation();

                string squareNotation = alNotator.GetSquareNotation(state.EnPassantTargetSquare);

                // spec says file letter should be lowercase
                builder.Append(squareNotation.ToLower());
            }

        }
    }
}
