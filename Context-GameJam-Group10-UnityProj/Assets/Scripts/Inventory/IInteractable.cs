using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to TestInteractables, and used by the InteractionScript which belongs to the Player

public class IInteractable : MonoBehaviour {
    public int ID;
    public string ItemName;

    public IInteractable(int ID, string itemName) {
        this.ItemName = itemName;
        this.ID = ID;
    }

}
