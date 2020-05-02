using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySlot : Slot {

    public List<ItemInfo> deposited;

    void Start() {
        base.Start();

        hideWhenHeld = true;
    }

    void Update() {
        if (item != null) { //if an item is deposited, save it's item info and then destroy it
            ItemInfo info = item.GetComponent<Item>().info;
            DestroyItem();
            deposited.Add(info);
        }
    }

    
}
