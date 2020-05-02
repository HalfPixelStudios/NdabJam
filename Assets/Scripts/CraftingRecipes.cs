using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Crafting Recipe")]
public class CraftingRecipes: ScriptableObject {

    public List<ItemInfo> input1;
    public List<ItemInfo> input2;
    public ItemInfo output;

    public static ItemInfo Craft(ItemInfo item1, ItemInfo item2) {

        foreach(var recipe in Global.craftingRecipes) {

            if (recipe.CanCraft(item1,item2)) {
                return recipe.output;
            }
        }

        return null;
    }

    public bool CanCraft(ItemInfo item1, ItemInfo item2) {

        if (!input1.Contains(item1)) { return false; }
        if (!input2.Contains(item2)) { return false; }

        return true;
    }
}
