using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Crafting Recipe")]
public class CraftingRecipes: ScriptableObject {

    public ItemInfo input1;
    public ItemInfo input2;
    public ItemInfo output;

}
