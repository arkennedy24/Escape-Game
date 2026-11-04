using UnityEngine;
using UnityEngine.UI;

// Manages the activation and deactivation of interactive elements within a specific area of interest
// should be placed on an area of interest in the scene
//drag the interactive elements into the areasInteractibles array in the inspector
public class AreaOfInterestManager : MonoBehaviour
{
    public ZoomInScript zoomInScript;
    public GameObject[] areasInteractibles;
    
    // Activates the area of interest by enabling all interactive elements within it
    public void ActivateArea()
    {
        for (int i = 0; i < areasInteractibles.Length; i++)
        {
            // areasInteractibles[i].SetActive(true);
            areasInteractibles[i].GetComponent<Button>().enabled = true;
        }
    }

    // Deactivates the area of interest by disabling all interactive elements within it
    public void DeactivateArea()
    {
        for (int i = 0; i < areasInteractibles.Length; i++)
        {
            areasInteractibles[i].GetComponent<Button>().enabled = false;
        }
    }


    void Start()
    {
         for (int i = 0; i < areasInteractibles.Length; i++)
        {
            areasInteractibles[i].SetActive(true);
            areasInteractibles[i].GetComponent<Button>().enabled = false;
        }
    }

}
