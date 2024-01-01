namespace ChessEngineTestUI.Game.Test
{
    public class UnitTest
    {
        [Fact]
        public void FenParsing()
        {
            BoardPositionGenerator generator = new BoardPositionGenerator();

            IBoard startingPos = generator.GetNewGameStartingPosition();

            DebugPrinter printer = new DebugPrinter();

            string board = printer.PrintBoardPosition(startingPos);

            Console.WriteLine(board);
        }
    }
}