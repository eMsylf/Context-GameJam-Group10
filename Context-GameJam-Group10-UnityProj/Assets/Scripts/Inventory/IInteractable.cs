using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IInteractable : MonoBehaviour
{
    public string ObjectName;

    private void Start() {
        ObjectName = name;
    }
    // This script is attached to test interactables, and used by the InteractionScript that belongs to the Player


}
