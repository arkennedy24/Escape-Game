using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public TMP_Text Inventory_Slot1_Text;
    public TMP_Text Inventory_Slot1_TextNumber;
    public TMP_Text Inventory_Slot2_Text;
    public TMP_Text Inventory_Slot2_TextNumber;
    public TMP_Text Inventory_Slot3_Text;
    public TMP_Text Inventory_Slot3_TextNumber;
    public TMP_Text Inventory_Slot4_Text;
    public TMP_Text Inventory_Slot4_TextNumber;
    public TMP_Text Inventory_Slot5_Text;
    public TMP_Text Inventory_Slot5_TextNumber;
    public TMP_Text Inventory_Slot6_Text;
    public TMP_Text Inventory_Slot6_TextNumber;
    // public SpriteRenderer Inventory_Slot1_Icon;
    // public SpriteRenderer Inventory_Slot2_Icon;
    // public SpriteRenderer Inventory_Slot3_Icon;
    // public SpriteRenderer Inventory_Slot4_Icon;
    // public SpriteRenderer Inventory_Slot5_Icon;
    // public SpriteRenderer Inventory_Slot6_Icon;
    public Image original;
    public Sprite keySprite;
    public Sprite puzzlePieceSprite;
    public Sprite emptySprite;
    // 2. Create the list using your custom class
    public List<InventoryItem> inventory = new();

    public void ItemCollect()
    {
        Debug.Log(ButtonName() + " collected");
         AddItem(ButtonName(), 1);
         PrintInventory();
         UpdateInventoryUI();
    }
    
    public void UpdateInventoryUI()
    {
        // Inventory_Slot1_Icon.sprite = inventory.Count > 0 ? GetSpriteForItem(inventory[0].itemName) : null;
        Inventory_Slot1_Text.text = inventory.Count > 0 ? inventory[0].itemName : "";
        Inventory_Slot2_Text.text = inventory.Count > 1 ? inventory[1].itemName : "";
        Inventory_Slot3_Text.text = inventory.Count > 2 ? inventory[2].itemName : "";
        Inventory_Slot4_Text.text = inventory.Count > 3 ? inventory[3].itemName : "";
        Inventory_Slot5_Text.text = inventory.Count > 4 ? inventory[4].itemName : "";
        Inventory_Slot6_Text.text = inventory.Count > 5 ? inventory[5].itemName : "";

        NewImage(inventory.Count > 0 ? GetSpriteForItem(inventory[0].itemName) : null);

        Inventory_Slot1_TextNumber.text = inventory.Count > 0 ? inventory[0].quantity.ToString() : "0";
        Inventory_Slot2_TextNumber.text = inventory.Count > 1 ? inventory[1].quantity.ToString() : "0";
        Inventory_Slot3_TextNumber.text = inventory.Count > 2 ? inventory[2].quantity.ToString() : "0";
        Inventory_Slot4_TextNumber.text = inventory.Count > 3 ? inventory[3].quantity.ToString() : "0";
        Inventory_Slot5_TextNumber.text = inventory.Count > 4 ? inventory[4].quantity.ToString() : "0";
        Inventory_Slot6_TextNumber.text = inventory.Count > 5 ? inventory[5].quantity.ToString() : "0";
    }

    public Sprite GetSpriteForItem(string itemName)
    {
        if (itemName == "Key")
        {
            Debug.Log("Key sprite returned");
            return keySprite;
        }
        else if (itemName == "Puzzle Piece")
        {
            return puzzlePieceSprite;
        }

        return null;
    }

    public string ButtonName()
        {
            // Automatically fetches the name of the button that was clicked
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;

            return clickedButton != null ? clickedButton.name : string.Empty;
        }
        [System.Serializable]
public class InventoryItem
{
    public string itemName;
    public int quantity;

    // A constructor makes it easy to add items via code
    public InventoryItem(string name, int amount)
    {
        itemName = name;
        quantity = amount;
    }
}

public void NewImage(Sprite sprite)
    {
        original.sprite = sprite; // Example: set the original image to the key sprite
    }


    // 3. Helper method to manage adding/stacking items
    public void AddItem(string name, int amount)
    {
        // Check if the item already exists in the list
        InventoryItem existingItem = inventory.Find(item => item.itemName == name);

        if (existingItem != null)
        {
            // If it exists, just increase the quantity
            existingItem.quantity += amount;
        }
        else
        {
            // If it's a new item, create it and add it to the list
            inventory.Add(new(name, amount));
        }
    }

    // Optional: Helper method to print the inventory to the console
    void PrintInventory()
    {
        foreach (InventoryItem item in inventory)
        {
            Debug.Log($"Item: {item.itemName} | Quantity: {item.quantity}");
        }
    }

        void Start()
    {
        UpdateInventoryUI();
        NewImage(emptySprite);
    }

}
