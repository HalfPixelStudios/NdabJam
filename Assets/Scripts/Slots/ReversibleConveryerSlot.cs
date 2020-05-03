using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversibleConveryerSlot : ConveyerSlot {

    public Slot prevNode;

    public bool isReverse;
    public Animator anim;

    void Start() {
        base.Start();

        updateConveyer();
    }

    public static void ReverseDirection(GameObject conveyerRoot) {

        ReversibleConveryerSlot[] slots = conveyerRoot.GetComponentsInChildren<ReversibleConveryerSlot>();

        foreach (var slot in slots) {
            slot.isReverse = !slot.isReverse;
            slot.updateConveyer();

        }

    }

    void updateConveyer() {
        //swap directions
        Slot temp = nextNode;
        nextNode = prevNode;
        prevNode = temp;

        //change sprite

        anim.SetBool("isReverse", isReverse);
    }
}
