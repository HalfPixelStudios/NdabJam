using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerSlot : Slot {


    public float conveyerSpeed;
    public float passDist;

    public ConveyerSlot nextNode;


    void Start() {
        base.Start();
    }

    void Update() {
        
        if (item == null || nextNode == null || nextNode.item != null) { return; }

        item.transform.position = Vector3.MoveTowards(item.transform.position,nextNode.transform.position,conveyerSpeed*Time.deltaTime);


        //pass along object
        var distToNext = Vector3.Distance(item.transform.position,nextNode.transform.position);
        if (distToNext < passDist) {
            nextNode.item = this.item;
            this.item = null;
        }
    }
}
