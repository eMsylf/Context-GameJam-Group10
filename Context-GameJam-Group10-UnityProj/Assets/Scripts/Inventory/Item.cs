using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : IInteractable{
    public bool IsCombinedItem;
    public SpriteRenderer SpriteRenderer;
    public Sprite Sprite;

    public Item(int ID, string itemName, bool isCombinedItem, SpriteRenderer spriteRenderer) : base(ID, itemName) {
        this.ID = ID;
        this.ItemName = itemName;
        this.IsCombinedItem = isCombinedItem;
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.SpriteRenderer = spriteRenderer;
    }

    private void Start() {
        if (Sprite == null) {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Sprite = SpriteRenderer.sprite;

        }
    }

}
