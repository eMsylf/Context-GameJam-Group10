﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {
    public int[] Slots;
    public GameObject[] Items;

    private void Awake() {
        //private instance = this;
    }
}
