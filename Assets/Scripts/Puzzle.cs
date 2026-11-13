
using UnityEngine;

[System.Serializable]
public class Puzzle
    {
        [SerializeField] string puzzleName;
        [SerializeField] string puzzlePieceName;
        [SerializeField] int puzzlePieceAmount;
        [SerializeField] bool puzzleIsSolved;
        [SerializeField] int piecesPlaced;
        

        // A constructor makes it easy to add items via code
        public Puzzle(string name, string pieceName, int amountOfPieces, bool isSolved)
        {
            puzzleName = name;
            puzzlePieceName = pieceName;
            puzzlePieceAmount = amountOfPieces;
            puzzleIsSolved = isSolved;
            piecesPlaced = 0;
        }

        public string PuzzleName
    {
        get { return puzzleName; }
        set { puzzleName = value; }
    }

        public string PuzzlePieceName
        {
            get { return puzzlePieceName; }
            set { puzzlePieceName = value; }
        }

        public int PuzzlePieceAmount
        {
            get { return puzzlePieceAmount; }
            set { puzzlePieceAmount = value; }
        }

        public bool PuzzleIsSolved
        {
            get { return puzzleIsSolved; }
            set { puzzleIsSolved = value; }
        }

        public int PiecesPlaced
        {
            get { return piecesPlaced; }
            set { piecesPlaced = value; }
        }
    }