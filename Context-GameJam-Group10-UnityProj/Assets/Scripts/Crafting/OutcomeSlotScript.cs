using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutcomeSlotScript : MonoBehaviour
{
    public Item HeldItem;
    public Image ItemImage;
    public Sprite ItemSprite;
    void Start()
    {
        ItemSprite = GetComponent<Image>().sprite;
    }

    void Update()
    {
        
    }
}
