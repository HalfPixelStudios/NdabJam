using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlot : Slot {

    public float pickup_radius;

    private void Start() {
        CircleCollider2D col = gameObject.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
        col.radius = pickup_radius;
    }


    private void OnTriggerStay2D(Collider2D other) {

        Slot slot = other.GetComponent<Slot>();
        if (slot) { //if the other thing actually has the slot compenet
            if (Input.GetKey(KeyCode.E)) {
                if (this.item == null && slot.item != null) { //take item from slot

                    this.item = slot.item;
                    slot.item = null;

                } else if (slot.item == null && this.item != null) { //otherwise put item into slot

                    slot.item = this.item;
                    this.item = null;
                    
                }
                
            }
        }
    }
}
