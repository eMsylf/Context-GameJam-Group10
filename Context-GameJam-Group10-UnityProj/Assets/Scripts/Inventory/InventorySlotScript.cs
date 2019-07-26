using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour {
    public Item HeldItem;
    public Image ItemImage;
    public Button ItemRemoveButton;
    public int slotNumber;
    public CraftingSlotScript CraftingSlotReference;
}
