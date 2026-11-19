using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsUIPanel : MonoBehaviour
{
    // apply this script to the canvas used for the settings panel

    public GameObject settingsPanel;
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

            Debug.Log("Setting menu active");
        }

        else if (Keyboard.current.escapeKey.wasPressedThisFrame && isPaused == true)
        {
            settingsPanel.SetActive(false);
            isPaused = false;
            Time.timeScale = 1;

            Debug.Log("Setting menu disabled");
        }

    }
}
