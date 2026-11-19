using UnityEngine;

// PiecesManager handles the management of puzzle pieces, including activating and updating their visibility based on the number of pieces placed in a puzzle.

public class PiecesManager : MonoBehaviour
{
     [SerializeField] GameObject[] Puzzle_PiecesSprites;
    public string puzzleName; // Name of the puzzle associated with this PiecesManager

     // Activates the puzzle piece at the specified index
     public void ActivatePiece(int index)
     {
         if (index >= 0 && index < Puzzle_PiecesSprites.Length)
         {
             Puzzle_PiecesSprites[index].SetActive(true);
         }
     }


     // Updates the visibility of all puzzle pieces based on the number of pieces placed
     public void UpdateAllPieces(int piecesPlaced)
     {
        Debug.Log("Updating all pieces with piecesPlaced: " + piecesPlaced);
         for (int i = 0; i < Puzzle_PiecesSprites.Length; i++)
         {
            Debug.Log("Checking piece " + i + " against piecesPlaced: " + piecesPlaced);
            if (i < piecesPlaced){
             Puzzle_PiecesSprites[i].SetActive(true);
            }
         }
     }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Puzzle_PiecesSprites.Length; i++)
        {
            Debug.Log(Puzzle_PiecesSprites[i]);
            Puzzle_PiecesSprites[i].SetActive(false);
            Debug.Log(Puzzle_PiecesSprites[i].name + "Puzzle Piece " + i + " is set to inactive.");
        }
    }

}
