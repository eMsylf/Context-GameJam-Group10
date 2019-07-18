using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : IInteractable{
    public Item(int ID, string itemName) : base(ID, itemName) {
        this.ID = ID;
        this.ItemName = itemName;
    }
}
