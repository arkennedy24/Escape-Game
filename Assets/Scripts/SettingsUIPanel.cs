using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class SettingsUIPanel : MonoBehaviour
{
    // apply this script to the canvas used for the settings panel
    // pauses timer in game as well as pauses the BGM when in settings menu

    public GameObject settingsPanel;
    public AudioSource bGM;

    public bool isPaused = false;

    void Start()
    {
        settingsPanel.SetActive(false);       
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame && isPaused == false)
        {
            settingsPanel.SetActive(true);
            isPaused = true;
            Time.timeScale = 0;

            bGM.Pause();

            Debug.Log("Setting menu active");
        }

        else if (Keyboard.current.escapeKey.wasPressedThisFrame && isPaused == true)
        {
            settingsPanel.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;

            bGM.Play();

            Debug.Log("Setting menu disabled");
        }

    }
}
