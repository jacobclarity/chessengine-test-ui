using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessEngineTestUI.Game
{
    public class DebugPrinter
    {
        public string PrintBoardPosition(IBoard board)
        {
            // output will look like this

            //  +---+---+---+---+---+---+---+---+
            //  | r | n | b | q | k | b | n | r | 8
            //  +---+---+---+---+---+---+---+---+
            //  | p | p | p | p | p | p | p | p | 7
            //  +---+---+---+---+---+---+---+---+
            //  |   |   |   |   |   |   |   |   | 6
            //  +---+---+---+---+---+---+---+---+
            //  |   |   |   |   |   |   |   |   | 5
            //  +---+---+---+---+---+---+---+---+
            //  |   |   |   |   |   |   |   |   | 4
            //  +---+---+---+---+---+---+---+---+
            //  |   |   |   |   |   |   |   |   | 3
            //  +---+---+---+---+---+---+---+---+
            //  | P | P | P | P | P | P | P | P | 2
            //  +---+---+---+---+---+---+---+---+
            //  | R | N | B | Q | K | B | N | R | 1
            //  +---+---+---+---+---+---+---+---+
            //    a   b   c   d   e   f   g   h

            StringBuilder builder = new StringBuilder();

            string horizontalLine = "+---+---+---+---+---+---+---+---+";
            string fileSeparator = "|";

            AlgebraicNotation alNotator = new AlgebraicNotation();

            builder.AppendLine(horizontalLine);

            for (int rank = 8; rank >= 1; --rank)
            {
                builder.Append(fileSeparator).Append(" ");

                // pieces and separators in rank

                for (int file = 1; file <= 8; ++file)
                {
                    ISquareData square = board.GetSquare(rank, file);

                    if (square.PieceType == PieceType.Empty)
                        builder.Append(" ");
                    else
                    {
                        char pieceLetter = alNotator.GetPieceLetterForPieceAndColor(square.PieceType, square.PieceColor);

                        builder.Append(pieceLetter);
                    }

                    builder.Append(" ").Append(fileSeparator).Append(" ");
                }

                // rank letter on end
                builder.AppendLine(rank.ToString());

                // border before next rank
                builder.AppendLine(horizontalLine);
            }

            // generate the file numbers

            builder.AppendLine("  a   b   c   d   e   f   g   h");

            return builder.ToString();
        }
    }
}
