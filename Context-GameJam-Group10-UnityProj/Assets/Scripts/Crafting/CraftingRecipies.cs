using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingRecipies : MonoBehaviour {
    public Item[] ListOfAllItemIngredients;
    public Item[] ListOfAllCombinedItems;

    void Start() {

    }

    void Update() {

    }

    // This acts as some kind of lookup table?
    public void DetermineCraftingOutcome(int ID0, int ID1) {
        for (int i = 0; i < ListOfAllItemIngredients.Length; i++) {
            for (int j = 0; j < ListOfAllItemIngredients.Length; j++) {
                if (ID0 == i && ID1 == j) {
                    //return itemID of Combined item
                    // dit werkt niet met het nieuwe idee, dat ik de volgorde van de items de uitkomst wil laten beïnvloeden
                    // hiervoor had ik meer uitkomst items nodig moeten hebben
                    // Sowieso is dit erg omslachtig 
                }
            }
        }
    }

    public int DetermineCraftingOutcome_V2(int ID0, int ID1) {
        switch (ID0) {
            case 0: // CD als basis
                switch (ID1) {
                    case 0: // CD als top
                        return 0; // Zonnepaneel
                    case 1: // Kartonnen doos als top
                        return 1; // Windmolen
                    default:
                        return -1;
                }
            case 1: // Kartonnen doos als basis
                switch (ID1) {
                    case 0: // CD als top
                        return 2; // Waterzuivering
                    case 1: // Kartonnen doos als top
                        return 3; // Broeikas
                    default:
                        return -1;
                }

            default:
                return -1;
        }
    }
}
