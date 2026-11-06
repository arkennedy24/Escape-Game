using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button rightButton;
    [SerializeField] Button leftButton;
    [SerializeField] int currentWall;
    [SerializeReference] GameObject[] walls;

    // Values for Wall panels:
    // Front Wall = 0
    // Right Wall = 1
    // Back Wall = 2
    // Left Wall = 3

    void Start()
    {
        rightButton.onClick.AddListener(RightButtonClick);
        leftButton.onClick.AddListener(LeftButtonClick);

        currentWall = 0;
        for (int i = 0; i <= walls.Length-1; i++)
        {
            Debug.Log(i);
            walls[i].SetActive(false);
        }

        walls[currentWall].SetActive(true);
    }

    void RightButtonClick()
    {
        currentWall += 1;

        if (currentWall == 4)
        {
            currentWall = 0;
        }

        for (int i = 0; i <= walls.Length-1; i++)
        {
            Debug.Log(i);
            walls[i].SetActive(false);
        }

        walls[currentWall].SetActive(true);

    }

    void LeftButtonClick()
    {
        currentWall -= 1;

        if (currentWall == -1)
        {
            currentWall = 3;
        }

        for (int i = 0; i <= walls.Length - 1; i++)
        {
            Debug.Log(i);
            walls[i].SetActive(false);
        }

        walls[currentWall].SetActive(true);

    }
}

// NOTE: make an empty GameObject (named "ButtonManager", etc.), and attach this script to it, assign walls to array list in inspector
// See values for panels @ top of script