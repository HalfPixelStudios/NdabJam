using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerSlot : Slot {


    public float conveyerSpeed;
    public float passDist;

    public Slot nextNode;


    void Start() {
        base.Start();
    }

    void Update() {
        
        if (item == null || nextNode == null || nextNode.item != null) { return; }

        //item.transform.position = Vector3.MoveTowards(item.transform.position,nextNode.transform.position,conveyerSpeed*Time.deltaTime);
        item.transform.position += (nextNode.transform.position - item.transform.position).normalized * conveyerSpeed * Time.deltaTime;

        //pass along object
        var distToNext = Vector3.Distance(item.transform.position,nextNode.transform.position);
        if (distToNext < passDist) {

            GameObject newItem = RemoveItem();
            //nextNode.SetItem(newItem);
            newItem.SetActive(!hideWhenHeld);

            nextNode.item = newItem;
        }
    }

    /*
    new void SetItem(GameObject item) {
        item.SetActive(!hideWhenHeld);

        this.item = item;
        //item.transform.parent = transform;
    }
    */

}
