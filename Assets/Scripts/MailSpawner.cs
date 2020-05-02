using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyerSlot))]
public class MailSpawner : MonoBehaviour {

    ConveyerSlot conveyer;

    void Start() {
        conveyer = GetComponent<ConveyerSlot>();
    }

    void Update() {
        
        if (conveyer.item != null) { return; }

        //spawn new mail parcel thingy
        GameObject[] parcels = Resources.LoadAll<GameObject>("Packages");
        GameObject randomParcel = Instantiate(parcels[Random.Range(0,parcels.Length)],conveyer.transform.position,Quaternion.identity);
        conveyer.item = randomParcel;
    }
}
