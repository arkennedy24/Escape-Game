using UnityEngine;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    // public TMP_Text[] Inventory_Slot_Texts;
    public TMP_Text[] Inventory_Slot_TextNumbers;
    public Image[] Inventory_Slot_Icons;
    public Sprite[] Inventory_Slot_Sprites;
    public Sprite emptySprite;
    [System.Serializable]
    // Custom class to represent an inventory item
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
    // 2. Create the list using custom class
    public List<InventoryItem> inventory = new();

    // Handles the collection of an item and updates the inventory accordingly
    public void ItemCollect()
    {
        Debug.Log(ButtonTag() + " collected");
         AddItem(ButtonTag(), 1);
         PrintInventory();
         UpdateInventoryUI();
    }

    // Handles the use of an item from the inventory
    public void ItemUse()
    {
        
        Debug.Log("Button name: " + ButtonName());
        int itemIndex = int.Parse(ButtonName());
        if (inventory.Count < itemIndex)
        {
            Debug.Log("Item index out of range");
            return;
        }
        else if (inventory[itemIndex - 1].quantity <= 0 || inventory[itemIndex - 1] == null)
        {
            Debug.Log("Item is out of stock or null");
            return;
        }
        else {
            Debug.Log("Item is valid and can be used");
            Debug.Log("Using item at index: " + itemIndex);
            Debug.Log("Item name: " + inventory[itemIndex - 1].itemName);
            Debug.Log(inventory[itemIndex - 1].itemName + " used");
             RemoveItem(inventory[itemIndex - 1].itemName);
            UpdateInventoryUI();
        }
    }

    // Handles the removal of an item from the inventory
    public void RemoveItem(string name)
    {
        InventoryItem existingItem = inventory.Find(item => item.itemName == name);
        if (existingItem != null)
        {
            existingItem.quantity -= 1;
            if (existingItem.quantity <= 0)
            {
                inventory.Remove(existingItem);
            }
        }
        UpdateInventoryUI();
    }
    
    // Updates the inventory UI based on the current inventory contents
    public void UpdateInventoryUI()
    {
        for (int i = 0; i < 6; i++)
        {
            // Inventory_Slot_Texts[i].text = inventory.Count > i ? inventory[i].itemName : "";
            Inventory_Slot_TextNumbers[i].text = inventory.Count > i ? inventory[i].quantity.ToString() : "0";
            NewImage(inventory.Count > i ? GetSpriteForItem(inventory[i].itemName) : emptySprite, i + 1);
        }
    }

    // Helper method to get the sprite for a specific item name
    public Sprite GetSpriteForItem(string itemName)
    {
        for (int i = 0; i < Inventory_Slot_Sprites.Length; i++)
            {
                if (Inventory_Slot_Sprites[i].name == itemName + "_0")
                {
                    return Inventory_Slot_Sprites[i];
                }
            }
        return null;
    }

// Helper method to get the name of the button that was clicked
    public string ButtonTag()
        {
            // Automatically fetches the name of the button that was clicked
            GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
            return clickedButton != null ? clickedButton.tag : string.Empty;
        }
    
    public string ButtonName()
    {
        GameObject clickedButton = EventSystem.current.currentSelectedGameObject;
        return clickedButton != null ? clickedButton.name : string.Empty;
    }

    // Updates the image in a specific inventory slot
    public void NewImage(Sprite sprite, int slotIndex)
    {
        Inventory_Slot_Icons[slotIndex - 1].sprite = sprite;
    }

    // adding/stacking items
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

    // Helper method to print the inventory to the console
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
        for (int i = 0; i <= 5; i++)
        {
            NewImage(emptySprite, i + 1);
        }
    }

}
