using UnityEngine;

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
