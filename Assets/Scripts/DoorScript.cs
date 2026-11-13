using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    [SerializeField] Sprite OpenSprite; // Assign the new sprite in the Inspector
    [SerializeField] Sprite ClosedSprite; // Assign the new sprite in the Inspector
    private bool isOpen = false; // Track the door's state

public void ToggleDoor()
    {
        isOpen = !isOpen; // Toggle the door state
        if (isOpen)
        {
            openDoor();
        }
        else
        {
            closeDoor();
        }
    }
 public void openDoor()
    {
        GetComponent<Button>().image.sprite = OpenSprite;
        transform.SetAsFirstSibling(); // Bring the door to the Back of the hierarchy
        Debug.Log("Door opened!");
    }

public void closeDoor()
    {
        GetComponent<Button>().image.sprite = ClosedSprite;
        transform.SetAsLastSibling(); // Send the door to the front of the hierarchy
        Debug.Log("Door closed!");
    }
}
