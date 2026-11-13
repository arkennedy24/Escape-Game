using UnityEngine;

public class PiecesManager : MonoBehaviour
{
     [SerializeField] GameObject[] Puzzle_PiecesSprites;
     public void ActivatePiece(int index)
     {
         if (index >= 0 && index < Puzzle_PiecesSprites.Length)
         {
             Puzzle_PiecesSprites[index].SetActive(true);
         }
     }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < Puzzle_PiecesSprites.Length; i++)
        {
            Debug.Log(Puzzle_PiecesSprites[i]);
            Puzzle_PiecesSprites[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
