using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSlot : Slot {


    void Start() {
        base.Start();

        hideWhenHeld = true;
    }

    void Update() {
        
        if (item != null) { //if theres an item, destory it
            DestroyItem();

            SoundPlayer.quickStart("Sounds/incinerator");
        }
    }
}
