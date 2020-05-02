using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer Global;

    public CraftingRecipes[] craftingRecipes;

    void Start() {
        Global = this;

        craftingRecipes = Resources.LoadAll<CraftingRecipes>("ScriptableObjects/CraftingRecipes");
        
    }

    void Update() {
        
    }
}
