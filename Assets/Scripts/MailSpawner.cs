using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyerNode))]
public class MailSpawner : MonoBehaviour {

    ConveyerNode conveyer;

    void Start() {
        conveyer = GetComponent<ConveyerNode>();
    }

    void Update() {
        
        if (conveyer.item != null) { return; }

        //spawn new mail parcel thingy
        GameObject[] parcels = Resources.LoadAll<GameObject>("Packages");
        GameObject randomParcel = Instantiate(parcels[Random.Range(0,parcels.Length)],conveyer.transform.position,Quaternion.identity);
        conveyer.item = randomParcel;
    }
}
