using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTestUI.Game
{
    public class GameStateGenerator
    {
        public GameState GetStartingPositionGameState()
        {
            return new GameState(PieceColor.White, CastlingAvailability.Both, CastlingAvailability.Both,
                                 null, 0, 1);
        }
    }
}
