using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSlot : Slot {

    public GameObject reverseableConveyerRoot;
    bool toggle = true;

    public override void Interact(Slot playerSlot) {
        toggle = !toggle;

        ReversibleConveryerSlot.ReverseDirection(reverseableConveyerRoot);
        /*
        if (toggle) { OnToggleOn(); }
        else { OnToggleOff(); }
        */
    }

    void OnToggleOn() {
        
    }
    void OnToggleOff() {

    }

    
}
