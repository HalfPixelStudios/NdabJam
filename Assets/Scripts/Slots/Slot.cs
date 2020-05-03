using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {

    public bool hideWhenHeld = false;
    public GameObject item;
    public Vector2 holdOffset;

    public bool allowTake = true;
    public bool allowPlace = true;
    public bool allowCraft = true;

    protected void Start() {

    }




    public virtual void Interact(Slot playerSlot) { //called by player when interacting

        if (playerSlot.item != null && item == null && allowPlace) { //player place item into slot

            GameObject newItem = playerSlot.RemoveItem();
            SetItem(newItem);

            SoundPlayer.quickStart("Sounds/pickup");
            return;

        }
        if (item != null && playerSlot.item == null && allowTake) { //otherwise player takes item from slot

            GameObject newItem = RemoveItem();
            playerSlot.SetItem(newItem);

            SoundPlayer.quickStart("Sounds/drop");
            return;

        }
        if (playerSlot.item != null && item != null && allowCraft) { //attempt crafting

            ItemInfo item1 = item.GetComponent<Item>().info;
            ItemInfo item2 = playerSlot.item.GetComponent<Item>().info;
            ItemInfo crafted = CraftingRecipes.Craft(item1, item2);

            if (crafted) { //if an item was successfully crafted
                GameObject newItem = Item.CreateItem(crafted);
                newItem.transform.position = item.transform.position;

                playerSlot.DestroyItem();
                DestroyItem();


                SetItem(newItem);

                SoundPlayer.quickStart("Sounds/craftSuccess");
            } else {
                SoundPlayer.quickStart("Sounds/craftError");
            }

        }

    }

    public void SetItem(GameObject item) {

        item.SetActive(!hideWhenHeld);

        this.item = item;
        item.transform.position = transform.position;
        item.transform.parent = transform;
        item.transform.localPosition = new Vector3(holdOffset.x, holdOffset.y, 0);

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
