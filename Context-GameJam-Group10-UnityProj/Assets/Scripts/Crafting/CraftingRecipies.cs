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
            case 0: // 
                switch (ID1) {
                    case 0:
                        return 0;
                    case 1:
                        return 1;
                    default:
                        return -1;
                }
            case 1:
                switch (ID1) {
                    case 0:
                        return 2;
                    case 1:
                        return 3;
                    default:
                        return -1;
                }

            default:
                return -1;
        }
    }
}
