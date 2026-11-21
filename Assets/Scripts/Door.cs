using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Door
{
    [SerializeField] GameObject doorObject;
    [SerializeField] bool isOpen;
    [SerializeField] bool needsKey;
    [SerializeField] bool isLocked;
    [SerializeField] GameObject keyObject;
    [SerializeField] Button doorButton;
    [SerializeField] string hint;
    [SerializeField] Sprite openSprite; // Assign the new sprite in the Inspector
    [SerializeField] Sprite closedSprite; // Assign the new sprite in the Inspector
    [SerializeField] bool puzzleSolved;

    public Door(GameObject doorObject, bool isOpen, bool needsKey, GameObject KeyObject, Sprite OpenSprite, Sprite ClosedSprite)
    {
        this.doorObject = doorObject;
        this.isOpen = isOpen;
        this.needsKey = needsKey;
        this.keyObject = KeyObject;
        this.openSprite = OpenSprite;
        this.closedSprite = ClosedSprite;
    }
    public string Hint
    {
        get { return hint; }
        set { hint = value; }
    }
    

    public bool IsLocked
    {
        get { return isLocked; }
        set { isLocked = value; }
    }
    public Sprite OpenSprite
    {
        get { return openSprite; }
        set { openSprite = value; }
    }

    public Sprite ClosedSprite
    {
        get { return closedSprite; }
        set { closedSprite = value; }
    }

    public GameObject KeyObject
    {
        get { return keyObject; }
        set { keyObject = value; }
    }

    public bool NeedsKey
    {
        get { return needsKey; }
        set { needsKey = value; } 
    }

    public bool IsOpen
    {
        get { return isOpen; }
        set { isOpen = value; }
    }
    public Button DoorButton
    {
        get { return doorButton; }
        set { doorButton = value; }
    }
    public GameObject DoorObject
    {
        get { return doorObject; }
        set { doorObject = value; }
    }
    //  public void openDoor()
    // {
    //     if (!needsKey)
    //     {
    //          doorButton.GetComponent<Button>().image.sprite = OpenSprite;
    //         doorButton.transform.SetAsFirstSibling(); // Bring the door to the Back of the hierarchy
    //         Debug.Log("Door opened!");
    //     }

    //  }
    //  public void closeDoor()
    //  {
    //     //Add param to get correct door//)
    //      doorButton.GetComponent<Button>().image.sprite = ClosedSprite;
    //      doorButton.transform.SetAsLastSibling(); // Send the door to the front of the hierarchy
    //      Debug.Log("Door closed!");
    //  }

     public string DoorName()
     {
         return doorObject.name;
     }
}
