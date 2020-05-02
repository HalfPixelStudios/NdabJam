using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteSlot : Slot {

    public ItemInfo infiniteItem;

    void Start() {
        base.Start();

        hideWhenHeld = true;
    }

    void Update() {
        
        if (item == null) { //if the item gets taken, fill it back up
            GameObject newItem = Item.CreateItem(infiniteItem);
            SetItem(newItem);

        }
    }
}
