using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DoorScript : MonoBehaviour
{
    public List<Door> doors = new();
    public InventoryManager inventoryManager;
    
    public void toggleDoor()
    {
        foreach (var door in doors)
        {    
            if (door.DoorName() == ButtonName())
            {
                 Debug.Log("Toggling door: " + door.DoorName());
                if (door.IsOpen)
                {
                    closeDoor(door);
                }
                else
                {
                    openDoor(door);
                }
            }
        }
    }

  public string ButtonName()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        return clickedButton != null ? clickedButton.name : string.Empty;
    }

     public void openDoor(Door door)
    {
        if (!door.NeedsKey)
        {
             door.DoorButton.GetComponent<Button>().image.sprite = door.OpenSprite;
            door.DoorButton.transform.SetAsFirstSibling(); // Bring the door to the Back of the hierarchy
            door.IsOpen = true;
            Debug.Log("Door opened!");
        }
        else
        {
            if (door.IsLocked)
            {
                Debug.Log("Door is locked!");
                Debug.Log("please use the key to unlock the door. Key: " + door.KeyObject.name);
                inventoryManager.DisplayMessage(door.Hint);
            }
            else
            {
                door.DoorButton.GetComponent<Button>().image.sprite = door.OpenSprite;
                door.DoorButton.transform.SetAsFirstSibling(); // Bring the door to the Back of the hierarchy
                Debug.Log("Door opened!");
                door.IsOpen = true;
            }
        }
     }
     public void closeDoor(Door door)
     {
        //Add param to get correct door//)
         door.DoorButton.GetComponent<Button>().image.sprite = door.ClosedSprite;
         door.DoorButton.transform.SetAsLastSibling(); // Send the door to the front of the hierarchy
         door.IsOpen = false;
         Debug.Log("Door closed!");
     }
    
}
