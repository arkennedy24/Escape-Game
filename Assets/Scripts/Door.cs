using UnityEngine;

[System.Serializable]
public class Door
{
    [SerializeField] GameObject doorObject;
    [SerializeField] bool isOpen;
    [SerializeField] bool hasKey;
    [SerializeField] GameObject KeyObject;

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
}
