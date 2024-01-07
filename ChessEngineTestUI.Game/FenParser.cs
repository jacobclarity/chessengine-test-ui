using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTestUI.Game
{
    public class FenParser
    {
        public BoardAndGameState ParseStartFromFenString(string fenString)
        {
            // input is like "rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 0 1"
            // for current board position and other game state

            // we will parse the board position and game state separately, so the first step
            // is to split out the two strings
            // board position is first, and ends at the first space character

            int firstSpace = fenString.IndexOf(" ");

            string boardPositionString = fenString.Substring(0, firstSpace);

            string gameStateString = fenString.Substring(firstSpace + 1);

            IBoard board = ParseBoardFromString(boardPositionString);

            // todo call sub functions
            return new BoardAndGameState(board, null);
        }

        private void AssertFenBoardPositionStringValid(string boardString)
        {
            // input like rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR

            List<char> rankPieceCharacters = new List<char>{ 'R', 'N', 'B', 'Q', 'K', 'P' };
            List<char> rankDigitCharacters = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            List<char> rankCharacters = new List<char>();

            rankCharacters.AddRange(rankPieceCharacters);
            rankCharacters.AddRange(rankDigitCharacters);

            List<char> fullBoardStringLegalCharacters = new List<char>();

            fullBoardStringLegalCharacters.AddRange(rankCharacters);
            fullBoardStringLegalCharacters.Add('/');

            for (int i = 0; i < boardString.Length; ++i)
                if (!fullBoardStringLegalCharacters.Contains(char.ToUpper(boardString[i])))
                    throw new Exception($"Failed to parse FEN string due to invalid character '{boardString[i]}' at position {i}, in fen string '{boardString}'");

            string[] rankStrings = boardString.Split("/");

            if (rankStrings.Length != 8)
                throw new Exception($"Failed to parse FEN string due to wrong numbers of ranks. Expected 8 ranks, found {rankStrings.Length} in string '{boardString}'");

            // the rank strings are ordered with 8th rank first, 1st rank last
            // so we start on 8, and each new rank string we go to the next lower rank

            AlgebraicNotation alNotator = new AlgebraicNotation();

            for (int rank = 8; rank >= 1; --rank)
            {
                // need to invert the array index, as index 0 is rank 8
                string rankString = rankStrings[8 - rank];

                if (string.IsNullOrWhiteSpace(rankString))
                    throw new Exception($"Failed to parse FEN string due to empty rank string on rank {rank} in string '{boardString}'");

                // each rank string should denote 8 placements, either pieces or blanks
                // so if we sum together 1 place per letter, and the numeric valid of each digit
                // it should equal 8
                int columnCount = 0;

                foreach (char c in rankString)
                {
                    if (char.IsDigit(c))
                    {
                        int emptySpaces = (int)char.GetNumericValue(c);

                        columnCount += emptySpaces;
                    }
                    else
                        columnCount += 1;
                }

                if (columnCount != 8)
                    throw new Exception($"Failed to parse FEN string due to incorrect column count {columnCount} in rank string '{rankString}'" +
                                        $" (rank={rank}) in FEN board position string '{boardString}'");

                // check if characters valid
                foreach (char c in rankString)
                {
                    bool isValidCharacter = rankCharacters.Contains(char.ToUpper(c));

                    if (!isValidCharacter)
                        throw new Exception($"Failed to parse FEN string due to invalid character '{char.ToUpper(c)}' in FEN board position string {boardString}");
                }
            }
        }

        private IBoard ParseBoardFromString(string boardString)
        {
            // input like rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR

            AssertFenBoardPositionStringValid(boardString);

            Board board = new Board();

            string[] rankStrings = boardString.Split("/");
            // the rank strings are ordered with 8th rank first, 1st rank last
            // so we start on 8, and each new rank string we go to the next lower rank
            int rank = 8;

            foreach (string rankString in rankStrings)
            {
                ParseRankFromRankString(rank, rankString, board);

                --rank;
            }

            return board;
        }

        // given FEN rank string, modifies board on rank to match the specified pieces
        private void ParseRankFromRankString(int rank, string rankString, Board board)
        {
            // given input like "4P3", that rank has 4 empty spaces, a white pawn, and 3 empty spacse

            AlgebraicNotation alNotator = new AlgebraicNotation();

            int file = 1;

            foreach (char character in rankString)
            {
                if (char.IsDigit(character))
                {
                    // number indicating blank spaces in the rank

                    int emptySpaces = (int)char.GetNumericValue(character);

                    file += emptySpaces;
                }
                else
                {
                    // piece

                    PieceType piece = alNotator.GetPieceTypeFromLetter(character);

                    PieceColor color = char.IsUpper(character) ? PieceColor.White : PieceColor.Black;

                    board.SetSquare(rank, file, piece, color);

                    ++file;
                }
            }
        }
    }
}
