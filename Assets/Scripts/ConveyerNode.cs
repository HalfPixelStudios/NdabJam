using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerNode : MonoBehaviour {


    public float conveyerSpeed;
    public float passDist;


    public GameObject currentObject;

    public ConveyerNode nextNode;

    void Start() {
        
    }

    void Update() {
        
        if (currentObject == null || nextNode == null || nextNode.currentObject != null) { return; }

        currentObject.transform.position = Vector3.MoveTowards(currentObject.transform.position,nextNode.transform.position,conveyerSpeed*Time.deltaTime);


        //pass along object
        var distToNext = Vector3.Distance(currentObject.transform.position,nextNode.transform.position);
        if (distToNext < passDist) {
            nextNode.currentObject = this.currentObject;
            this.currentObject = null;
        }
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position,0.1f);
    }
}
