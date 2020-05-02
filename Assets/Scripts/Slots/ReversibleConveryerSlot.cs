using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversibleConveryerSlot : ConveyerSlot {

    public Slot prevNode;

    bool isReverse;
    Animator anim;

    void Start() {
        base.Start();

        anim = GetComponent<Animator>();

    }

    public static void ReverseDirection(GameObject conveyerRoot) {

        ReversibleConveryerSlot[] slots = conveyerRoot.GetComponentsInChildren<ReversibleConveryerSlot>();

        foreach (var slot in slots) {

            //swap directions
            Slot temp = slot.nextNode;
            slot.nextNode = slot.prevNode;
            slot.prevNode = temp;

            //change sprite
            slot.isReverse = !slot.isReverse;
            slot.anim.SetBool("isReverse", slot.isReverse);
        }

    }
}
