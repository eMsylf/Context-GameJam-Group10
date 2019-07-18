using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawner : MonoBehaviour {

    public List<string> ItemVariations = new List<string> {"a", "b", "c"};
    public List<Item> ItemPool;
    
    

    public enum MyEnum {
        banana,
        takken,
        blik,
        box,
        candy,
        cd,
        chips,
        cigaret
    };

    public MyEnum myEnum;

    void Start() {
        //ItemPool.Add(Instantiate<>)
    }

    void Update() {

    }
}
