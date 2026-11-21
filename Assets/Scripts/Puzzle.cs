
using UnityEngine;

[System.Serializable]
public class Puzzle
    {
        [SerializeField] string puzzleName;
        [SerializeField] string puzzlePieceName;
        [SerializeField] int puzzlePieceAmount;
        [SerializeField] bool puzzleIsSolved;
        [SerializeField] GameObject completedActionObject;
        [SerializeField] int piecesPlaced;
        [SerializeField] bool hasCompletedAction;
        

        // A constructor makes it easy to add items via code
        public Puzzle(string name, string pieceName, int amountOfPieces, bool isSolved, bool doesHaveCompletedAction)
        {
            puzzleName = name;
            puzzlePieceName = pieceName;
            puzzlePieceAmount = amountOfPieces;
            puzzleIsSolved = isSolved;
            piecesPlaced = 0;
            hasCompletedAction = doesHaveCompletedAction;
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
        public GameObject CompletedActionObject
        {
            get { return completedActionObject; }
            set { completedActionObject = value; }
        }

        public bool HasCompletedAction
        {
            get { return hasCompletedAction; }
            set { hasCompletedAction = value; }
        }
        

        public void CompleteAction(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
    }