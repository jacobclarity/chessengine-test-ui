using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    internal enum CastlingAvailability
    {
        Kingside,
        Queenside,
        Both,
        None
    }

    static class CastlingAvailabilityExtensions
    {
        public static bool CanCastleKingside(this CastlingAvailability castlingAvailability)
        {
            return castlingAvailability == CastlingAvailability.Kingside || castlingAvailability == CastlingAvailability.Both;
        }

        public static bool CanCastleQueenside(this CastlingAvailability castlingAvailability)
        {
            return castlingAvailability == CastlingAvailability.Queenside || castlingAvailability == CastlingAvailability.Both;
        }
    }
}
