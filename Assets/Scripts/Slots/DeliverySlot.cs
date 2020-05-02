using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySlot : Slot {

    public List<ItemInfo> acceptable;

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

    public int CalculateScore() {
        int score = 0;

        foreach (var info in deposited) {

            if (acceptable.Contains(info)) { //if correct
                score += info.correctPoints;
            } else {
                score += info.incorrectPoints;
            }
        }
        return score;
    }

    
}
