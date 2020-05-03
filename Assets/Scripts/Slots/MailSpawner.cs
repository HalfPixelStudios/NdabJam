using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ConveyerSlot))]
public class MailSpawner : MonoBehaviour {

    public List<ItemInfo> packages;
    public float spawnRate;
    ConveyerSlot conveyer;

    float spawnCounter = 0f;

    void Start() {
        conveyer = GetComponent<ConveyerSlot>();
    }

    void Update() {
        
        if (conveyer.item != null || packages.Count == 0) { return; }

        spawnCounter += Time.deltaTime;

        if (spawnCounter > spawnRate) {
            //spawn new mail parcel thingy
            ItemInfo randomParcel = packages[Random.Range(0, packages.Count)];
            GameObject newItem = Item.CreateItem(randomParcel);
            conveyer.SetItem(newItem);

            spawnCounter = 0;
        }

        
    }
}
