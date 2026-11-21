using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Door
{
    [SerializeField] GameObject doorObject;
    [SerializeField] bool isOpen;
    [SerializeField] bool hasKey;
    [SerializeField] GameObject KeyObject;
    [SerializeField] Button doorButton;
    [SerializeField] Sprite OpenSprite; // Assign the new sprite in the Inspector
    [SerializeField] Sprite ClosedSprite; // Assign the new sprite in the Inspector

    public Door(GameObject doorObject, bool isOpen, bool hasKey, GameObject KeyObject, Sprite OpenSprite, Sprite ClosedSprite)
    {
        this.doorObject = doorObject;
        this.isOpen = isOpen;
        this.hasKey = hasKey;
        this.KeyObject = KeyObject;
        this.OpenSprite = OpenSprite;
        this.ClosedSprite = ClosedSprite;
    }

    public Sprite OpenSpriteProperty
    {
        get { return OpenSprite; }
        set { OpenSprite = value; }
    }

    public Sprite ClosedSpriteProperty
    {
        get { return ClosedSprite; }
        set { ClosedSprite = value; }
    }

    public GameObject KeyObjectProperty
    {
        get { return KeyObject; }
        set { KeyObject = value; }
    }

    public bool HasKey
    {
        get { return hasKey; }
        set { hasKey = value; }
    }

    public bool IsOpen
    {
        get { return isOpen; }
        set { isOpen = value; }
    }

    public GameObject DoorObject
    {
        get { return doorObject; }
        set { doorObject = value; }
    }
     public void openDoor()
    {
            doorButton.GetComponent<Button>().image.sprite = OpenSprite;
         doorButton.transform.SetAsFirstSibling(); // Bring the door to the Back of the hierarchy
         Debug.Log("Door opened!");
     }
     public void closeDoor()
     {
        //Add param to get correct door//)
         doorButton.GetComponent<Button>().image.sprite = ClosedSprite;
         doorButton.transform.SetAsLastSibling(); // Send the door to the front of the hierarchy
         Debug.Log("Door closed!");
     }

     public string DoorName()
     {
         return doorObject.name;
     }
}
