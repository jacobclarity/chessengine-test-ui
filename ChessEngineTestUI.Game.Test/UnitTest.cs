namespace ChessEngineTestUI.Game.Test
{
    public class UnitTest
    {
        [Fact]
        public void TempRunCodePath()
        {
            // temporary testing of Game library code
            // that isn't intended to be an actual unit test
            FenParser parser = new FenParser();

            BoardAndGameState state = parser.ParseStartFromFenString("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1");

            ;
        }

        [Fact]
        public void FenSerializeStartingPosition()
        {
            BoardPositionGenerator positionGenerator = new BoardPositionGenerator();
            GameStateGenerator stateGenerator = new GameStateGenerator();

            IBoard startingPosition = positionGenerator.GetNewGameStartingPosition();

            GameState startingState = stateGenerator.GetStartingPositionGameState();

            BoardAndGameState fullState = new BoardAndGameState(startingPosition, startingState);

            FenSerializer fen = new FenSerializer();

            string fenStr = fen.GetFenStringForPosition(fullState);

            Assert.Equal("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1", fenStr);
        }
    }
}