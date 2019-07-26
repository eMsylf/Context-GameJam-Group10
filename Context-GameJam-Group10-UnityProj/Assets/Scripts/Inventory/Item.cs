using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IInteractable{
    public bool isCombinedItem;

    public Item(int ID, string itemName, bool isCombinedItem) : base(ID, itemName) {
        this.ID = ID;
        this.ItemName = itemName;
        this.isCombinedItem = isCombinedItem;
    }

}
