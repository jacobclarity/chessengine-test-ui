using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ChessEngineTestUI.Game
{
    internal class AlgebraicNotation
    {
        private readonly Dictionary<PieceType, char> _pieceLetterMap = new Dictionary<PieceType, char>()
        {
            {PieceType.King, 'K' },
            {PieceType.Queen, 'Q' },
            {PieceType.Rook, 'R' },
            {PieceType.Knight, 'N' },
            {PieceType.Bishop, 'B' },
            {PieceType.Pawn, 'P' }
        };

        private readonly Dictionary<char, PieceType> _letterPieceMap;

        private readonly Dictionary<int, char> _fileLetterMap = new Dictionary<int, char>()
        {
            {1, 'A'},
            {2, 'B'},
            {3, 'C' },
            {4, 'D' },
            {5, 'E' },
            {6, 'F' },
            {7, 'G' },
            {8, 'H' }
        };

        private readonly Dictionary<char, int> _letterFileMap;

        public AlgebraicNotation()
        {
            _letterPieceMap = CreateInverseDictionary(_pieceLetterMap);
            _letterFileMap = CreateInverseDictionary(_fileLetterMap);
        }

        private Dictionary<T2, T1> CreateInverseDictionary<T1, T2>(Dictionary<T1, T2> sourceDictionary)
            where T1: notnull
            where T2: notnull
        {
            Dictionary<T2, T1> invertedDictionary = new Dictionary<T2, T1>();

            foreach (KeyValuePair<T1, T2> pair in sourceDictionary)
                invertedDictionary[pair.Value] = pair.Key;

            return invertedDictionary;
        }

        public char GetPieceLetterForPieceAndColor(PieceType type, PieceColor color)
        {
            char letter;

            bool mapped = _pieceLetterMap.TryGetValue(type, out letter);

            if (!mapped)
                throw new Exception($"Failed to map piece type {type.ToString()} to a letter");

            if (color == PieceColor.White)
                return char.ToUpper(letter);
            else
                return char.ToLower(letter);
        }

        public PieceType GetPieceTypeFromLetter(char letter)
        {
            PieceType type;

            bool mapped = _letterPieceMap.TryGetValue(letter, out type);

            if (!mapped)
                throw new Exception($"Failed to map letter '{letter}' to a piece type");

            return type;
        }

        public PieceColor GetPieceColorFromLetter(char letter)
        {
            if (char.IsUpper(letter))
                return PieceColor.White;
            else
                return PieceColor.Black;
        }

        public char GetLetterFromFile(int file)
        {
            char letter;

            bool mapped = _fileLetterMap.TryGetValue(file, out letter);

            if (!mapped)
                throw new Exception($"Failed to map file number {file} to a letter");

            return letter;
        }

        public int GetFileFromLetter(char letter)
        {
            int file;

            bool mapped = _letterFileMap.TryGetValue(char.ToUpper(letter), out file);

            if (!mapped)
                throw new Exception($"Failed to map file letter {letter} to a file number");

            return file;
        }

        public string GetSquareNotation(SquarePosition position)
        {
            return string.Concat(GetLetterFromFile(position.File), position.Rank);
        }
    }
}
