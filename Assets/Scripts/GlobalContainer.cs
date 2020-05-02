using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GlobalContainer : MonoBehaviour {

    public static GlobalContainer Global;

    public CraftingRecipes[] craftingRecipes;
    public GameObject nodeRoot;
    public Slot[] nodes;

    void Start() {
        Global = this;

        craftingRecipes = Resources.LoadAll<CraftingRecipes>("ScriptableObjects/CraftingRecipes");
        nodes = nodeRoot.GetComponentsInChildren<Slot>();
    }

    void Update() {
        
    }
}
