using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSlot : Slot {

    public GameObject reverseableConveyerRoot;
    bool toggle = true;
    public Animator anim;

    private void Start() {
        base.Start();

    }
    public override void Interact(Slot playerSlot) {
        toggle = !toggle;

        ReversibleConveryerSlot.ReverseDirection(reverseableConveyerRoot);
        anim.Play("greenSwitch", 0, toggle ? 0 : 0.9f);

        SoundPlayer.quickStart(toggle ? "Sounds/switchOn" : "Sounds/switchOff");
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
