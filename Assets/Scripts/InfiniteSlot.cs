using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSlot : Slot {

    public GameObject infiniteItem;

    void Start() {
        
    }

    void Update() {
        
        if (item == null) { //if the item gets taken, fill it back up
            GameObject newItem = Instantiate(infiniteItem);
            item = newItem;

        }
    }
}
