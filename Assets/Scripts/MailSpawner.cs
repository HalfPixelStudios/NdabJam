using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyerSlot))]
public class MailSpawner : MonoBehaviour {

    public List<ItemInfo> packages;
    ConveyerSlot conveyer;

    void Start() {
        conveyer = GetComponent<ConveyerSlot>();
    }

    void Update() {
        
        if (conveyer.item != null || packages.Count == 0) { return; }

        //spawn new mail parcel thingy
        ItemInfo randomParcel = packages[Random.Range(0,packages.Count)];
        GameObject newItem = Item.CreateItem(randomParcel);
        conveyer.SetItem(newItem);

        
    }
}
