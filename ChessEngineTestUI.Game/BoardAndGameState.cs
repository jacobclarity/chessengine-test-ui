using System;
using System.Collections.Generic;
using System.Text;

namespace ChessEngineTestUI.Game
{
    internal class BoardAndGameState
    {
        public IBoard Board { get; }
        public GameState GameState { get; }

        public BoardAndGameState(IBoard board, GameState gameState)
        {
            this.Board = board;
            this.GameState = gameState;
        }
    }
}
