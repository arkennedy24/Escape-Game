using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button rightButton;
    [SerializeField] Button leftButton;
    [SerializeField] GameObject frontWall;
    [SerializeField] GameObject rightWall;

    void Start()
    {
        rightButton.onClick.AddListener(RightButtonClick);
        leftButton.onClick.AddListener(LeftButtonClick);
    }

    void RightButtonClick()
    {
        if (frontWall.activeInHierarchy)
        {
            frontWall.SetActive(false);
            rightWall.SetActive(true);
        }

    }
            
    void LeftButtonClick()
    {
        if (rightWall.activeInHierarchy)
        {
            frontWall.SetActive(true);
            rightWall.SetActive(false);
        }
    }
}

// NOTE: make an empty GameObject (named "ButtonManager", etc.), and attach this script to it, choose your buttons and panels in Inspector
// Mecca note to self - figure out how to go back to Wall 1 later + add other Walls/panels soon lol