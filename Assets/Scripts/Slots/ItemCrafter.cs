using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Slot))]
public class ItemCrafter : MonoBehaviour {

    public ItemInfo craftingItem;
    Slot slot;

    void Start() {
        slot = GetComponent<Slot>();
    }


    void Update() {
        
        if (slot.item != null) { //attempt to craft

            ItemInfo inputItem = slot.item.GetComponent<Item>().info;
            ItemInfo crafted = CraftingRecipes.Craft(inputItem,craftingItem);

            if (crafted) {
                slot.DestroyItem();
                slot.SetItem(Item.CreateItem(crafted));
            }
        }
    }
}
