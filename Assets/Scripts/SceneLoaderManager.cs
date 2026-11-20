using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : MonoBehaviour
{
    // add this script to your Canvas gameobject, then click and drag the Canvas gameobject into the OnClick() selector

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
        Debug.Log("Loading main menu");
    }

    public void LoadMainLevel()
    {
        SceneManager.LoadScene("Main");
        Debug.Log("Loading main level");
    }

    public void MyQuit()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }

    // this is a temp. line, working in testing scene as of writing this
    public void LoadCurrentScene()
    {
        SceneManager.LoadScene("Mecca test");
        Debug.Log("loading testing scene");

    }
}