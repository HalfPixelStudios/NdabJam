using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public ItemInfo info;

    void Start() {
        
    }


    void Update() {
        
    }

    public static GameObject CreateItem(ItemInfo info) {
        GameObject newItem = new GameObject();
        Item i = newItem.AddComponent<Item>();
        SpriteRenderer sr = newItem.AddComponent<SpriteRenderer>();

        i.info = info;

        //assign other unique properties and shit here

        //sr.sprite = info.sprite


        return newItem;

    }
}
