using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public bool hideWhenHeld = false;
    public GameObject item;
    public Vector2 holdOffset;

    protected void Start() {

    }


    public void SetItem(GameObject item) {

        item.SetActive(!hideWhenHeld);

        this.item = item;
        item.transform.position = transform.position;
        item.transform.parent = transform;
        item.transform.localPosition = new Vector3(holdOffset.x, holdOffset.y, 0);

    }

    public void Interact(Slot playerSlot) { //called by player when interacting

        if (playerSlot.item != null && item == null) { //player place item into slot

            GameObject newItem = playerSlot.RemoveItem();
            SetItem(newItem);
            return;

        }
        if (item != null && playerSlot.item == null) { //otherwise player takes item from slot

            GameObject newItem = RemoveItem();
            playerSlot.SetItem(newItem);
            return;

        }
        if (playerSlot.item != null && item != null) { //attempt crafting

            ItemInfo item1 = item.GetComponent<Item>().info;
            ItemInfo item2 = playerSlot.item.GetComponent<Item>().info;
            ItemInfo crafted = CraftingRecipes.Craft(item1, item2);

            if (crafted) { //if an item was successfully crafted
                playerSlot.DestroyItem();
                DestroyItem();

                SetItem(Item.CreateItem(crafted));
            }

        }

    }

    public GameObject RemoveItem() {
        GameObject removed = this.item;
        this.item = null;
        return removed;
    }

    public void DestroyItem() {
        GameObject destroy = RemoveItem();
        Destroy(destroy);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
