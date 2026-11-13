using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle> puzzles = new();
    // public InventoryManager inventoryManager;
    //  public Sprite[] Puzzle_PiecesSprites;
    public PiecesManager[] piecesManagers;
    public InventoryManager inventoryManager;
    public bool allPuzzlesSolved;

    public void InitializePuzzles()
    {
        puzzles.Add(new Puzzle("MouseHole", "Cheese", 1, false));
        puzzles.Add(new Puzzle("JigSaw", "Puzzle Piece", 3, false));
        // foreach (Puzzle puzzle in puzzles)
        // {

        //     Debug.Log("Puzzle Name: " + puzzle.PuzzleName);
        //     Debug.Log("Puzzle Piece Name: " + puzzle.PuzzlePieceName);
        //     Debug.Log("Puzzle Piece Amount: " + puzzle.PuzzlePieceAmount);
        //     Debug.Log("Puzzle Is Solved: " + puzzle.PuzzleIsSolved);
        // }
    }
    public void PlacePuzzlePiece(Puzzle puzzle, Sprite pieceSprite)
    {
        puzzle.PiecesPlaced++;
        if (puzzle.PiecesPlaced >= puzzle.PuzzlePieceAmount)
        {
            puzzle.PuzzleIsSolved = true;
        }
    }
    public bool IsPuzzleSolved(Puzzle puzzle)
    {
        return puzzle.PuzzleIsSolved;
    }


    public void UpdatePuzzle(Puzzle puzzle)
    {
        if (puzzle.PiecesPlaced >= puzzle.PuzzlePieceAmount)
        {
            puzzle.PuzzleIsSolved = true;
        }
        Debug.Log("updating puzzle: " + puzzle.PuzzleName + ", Index: " + GetPuzzleIndex(puzzle));
        piecesManagers[GetPuzzleIndex(puzzle)].ActivatePiece(puzzle.PiecesPlaced - 1);
        
        if (puzzle.PuzzleIsSolved)
        {
            Debug.Log("Puzzle solved!");
            inventoryManager.DisplayMessage("Puzzle solved!");
            for(int i = 0; i < puzzles.Count; i++)
            {
                Debug.Log(puzzles[i].PuzzleName + ": " + puzzles[i].PuzzleIsSolved + "Checked");
                if(puzzles[i].PuzzleIsSolved == false)
                {
                    allPuzzlesSolved = false;
                    Debug.Log("Not all puzzles solved!");
                    break;
                }
                else
                {
                    allPuzzlesSolved = true;
                }
                // puzzles[i].PuzzleIsSolved = true;
            }
        }
        if (allPuzzlesSolved)
        {
            Debug.Log("All puzzles solved!");
            inventoryManager.DisplayMessage("All puzzles solved!");
             SceneManager.LoadScene("WinScene");
        }
    }

    public void TryToUsePuzzlePiece(Puzzle puzzle, string itemName)
    {
        if (puzzle.PuzzlePieceName == itemName)
        {
            PlacePuzzlePiece(puzzle, null);
            UpdatePuzzle(puzzle);
            Debug.Log("Puzzle piece used successfully: " + itemName + " for puzzle: " + puzzle.PuzzleName);
        }
        else
        {
            Debug.Log("Item does not match the selected puzzle area");
            inventoryManager.DisplayMessage("Item cannot be used here");
        }
    }

    public int GetPuzzleIndex(Puzzle puzzle)
    {
        return puzzles.IndexOf(puzzle);
    }
    public int GetPuzzleIndexByName(string puzzleName)
    {
        for (int i = 0; i < puzzles.Count; i++)
        {
            if (puzzles[i].PuzzleName == puzzleName)
            {
                return i;
            }
        }
        return -1; // Return -1 if the puzzle is not found
    }
    public Puzzle GetPuzzleByName(string puzzleName)
    {
        foreach (Puzzle puzzle in puzzles)
        {
            if (puzzle.PuzzleName == puzzleName)
            {
                return puzzle;
            }
        }
        return null; // Return null if the puzzle is not found
    }
    
    public bool CheckAllPuzzlesSolved()
    {
        foreach (Puzzle puzzle in puzzles)
        {
            if (!puzzle.PuzzleIsSolved)
            {
                return false;
            }
        }
        return true;
    }
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializePuzzles();
    }

}
