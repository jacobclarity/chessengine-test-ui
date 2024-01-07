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

            BoardAndGameState state = parser.ParseStartFromFenString("7r/2p5/1p1pkp2/pP3R2/P1P1P1Pp/3n1P1P/R5K1/8 w - - 2 46");

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