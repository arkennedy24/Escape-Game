using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

// PuzzleManager handles the management of puzzles, including placing puzzle pieces, updating puzzle states, and checking if all puzzles are solved.

public class PuzzleManager : MonoBehaviour
{
    public List<Puzzle> puzzles = new();
    public PiecesManager[] piecesManagers;
    public InventoryManager inventoryManager;
    public DoorScript doorManager;
    public List<Door> doors;
    public bool allPuzzlesSolved;

    private void Awake()
    {
        if (doorManager == null)
        {
            doorManager = GetComponent<DoorScript>();
        }

        if (doorManager != null)
        {
            doors = doorManager.doors;
        }
    }
   


// Initializes the puzzles with their names, piece names, and the number of pieces required to solve them
    // public void InitializePuzzles()
    // {
    //     puzzles.Add(new Puzzle("JigSaw", "Puzzle Piece", 4, false, false));
    //     puzzles.Add(new Puzzle("MouseHole", "Cheese", 1, false, true));
    // }


// Places a puzzle piece in the specified puzzle and updates the puzzle state
    public void PlacePuzzlePiece(Puzzle puzzle, Sprite pieceSprite)
    {
        puzzle.PiecesPlaced++;
        if (puzzle.PiecesPlaced >= puzzle.PuzzlePieceAmount)
        {
            puzzle.PuzzleIsSolved = true;
        }
    }


// Update the puzzle state and check if all puzzles are solved
    public void UpdatePuzzle(Puzzle puzzle)
    {
        foreach (Puzzle p in puzzles)
        {
            Debug.Log("Puzzle Name: " + p.PuzzleName + ", Pieces Placed: " + p.PiecesPlaced + ", Is Solved: " + p.PuzzleIsSolved);
        }
        Debug.Log("Updating all puzzle pieces should run next");
        Debug.Log("puzzles.count: " + puzzles.Count);
        

        //I Think this is where the code is breaking
        for (int i = 0; i < puzzles.Count; i++)
        {
            Debug.Log("Updating pieces for puzzle: " + puzzles[i].PuzzleName + ", Pieces Placed: " + puzzles[i].PiecesPlaced);

            // Figure out why this is Null???
            Debug.Log("piecesManagers[i]" + piecesManagers[i]);
            piecesManagers[i].UpdateAllPieces(puzzles[i].PiecesPlaced);
        }
        if (puzzle.PiecesPlaced >= puzzle.PuzzlePieceAmount)
        {
            puzzle.PuzzleIsSolved = true;
        }
        Debug.Log("updating puzzle: " + puzzle.PuzzleName + ", Index: " + GetPuzzleIndex(puzzle));
        // piecesManagers[GetPuzzleIndex(puzzle)].ActivatePiece(puzzle.PiecesPlaced - 1);
        

        if (puzzle.PuzzleIsSolved)
        {
            foreach (Door door in doors)
            {
                if (puzzle.PuzzleName == door.DoorObject.name)
                {
                    door.IsLocked = false;
                    door.IsOpen = true;
                    // door.DoorButton.GetComponent<Button>().image.sprite = door.OpenSprite;
                    
                    break;
                }
                // if (door.PuzzleSolved == false)
                // {
                //     door.PuzzleSolved = true;
                //     break;
                // }
            }
            Debug.Log("Puzzle solved!");
            inventoryManager.DisplayMessage("Puzzle solved!");
            if (puzzle.HasCompletedAction)
            {
                puzzle.CompleteAction(puzzle.CompletedActionObject);
            }
            
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

// Tries to use a puzzle piece in the specified puzzle and updates the puzzle state if successful
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


// Checks if a puzzle piece can be used in the specified puzzle
    public bool CanUsePuzzlePiece(Puzzle puzzle, string itemName)
    {
        Debug.Log("Checking if puzzle piece can be used: " + itemName + " for puzzle: " + puzzle.PuzzleName + ". Puzzle piece name: " + puzzle.PuzzlePieceName);
        return puzzle.PuzzlePieceName == itemName;
    }


// Gets the index of the specified puzzle in the puzzles list
    public int GetPuzzleIndex(Puzzle puzzle)
    {
        return puzzles.IndexOf(puzzle);
    }


// Gets the puzzle by its name from the puzzles list
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
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // void Start()
    // {
    //     InitializePuzzles();
        
    // }

}