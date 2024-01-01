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

            ;

            // todo call sub functions
            return new BoardAndGameState(null, null);
        }

        private IBoard ParseBoardFromString(string boardString)
        {
            // input like rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR

            Board board = new Board();

            AlgebraicNotation alNotator = new AlgebraicNotation();

            char[] pieceCharacters = new char[] { 'R', 'N', 'B', 'Q', 'K', 'P' };
            char[] digitCharacters = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] legalCharacters = new char[] { 'R', 'N', 'B', 'Q', 'K', 'P', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            for (int i = 0; i < boardString.Length; ++i)
                if (!legalCharacters.Contains(char.ToUpper(boardString[i])))
                    throw new Exception($"Failed to parse FEN string due to invalid character '{boardString[i]}' at position {i}, in fen string '{boardString}'");

            string[] rankStrings = boardString.Split("/");

            if (rankStrings.Length != 8)
                throw new Exception($"Failed to parse FEN string due to wrong numbers of ranks. Expected 8 ranks, found {rankStrings.Length} in string '{boardString}'");

            throw new Exception("Not implemented yet");

            /*
            for (int rank = 8; rank >= 0; --rank)
            {
                // the rank strings come in reverse order, where the 8th rank is the first index in the array
                // so we need to invert our index
                string rankString = rankStrings[8 - rank];

                if (string.IsNullOrWhiteSpace(rankString))
                    throw new Exception($"Failed to parse FEN string due to empty rank string on rank {rank} in string '{boardString}'");

                int file = 1;

                while (file <= 8)
                {
                    char character = boardString[stringCharacterIndex];

                    if (char.IsDigit(character))
                    {
                        // number indicating blank spaces in the rank
                        int emptySpaces = (int) char.GetNumericValue(character);

                        if (emptySpaces + file > 8)
                            throw new Exception("Failed to parse fen string, ")
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
        */
        
        
        }
    }
}
