using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class PlayerSlot : Slot {

    public float pickup_radius;


    private void Start() {

        /*
        //override superclass
        CircleCollider2D col = gameObject.AddComponent<CircleCollider2D>();
        col.isTrigger = true;
        col.radius = pickup_radius;
        */
    }

    private void Update() {

        


        if (Input.GetKeyDown(KeyCode.E)) {

            //look for closest node within reach distance

            Slot closest = null;
            float closestDist = float.PositiveInfinity;
            foreach (var slot in Global.nodes) {

                var dist = Vector3.Distance(slot.transform.position, transform.position);
                if (dist < closestDist && dist < pickup_radius) {
                    closestDist = dist;
                    closest = slot;
                }

            }

            if (closest) {
                if (this.item == null && closest.item != null) { //take item from slot

                    GameObject newItem = closest.RemoveItem();
                    SetItem(newItem);


                } else if (this.item != null) { //otherwise put item into slot

                    
                    if (closest.item == null) {
                        GameObject newItem = RemoveItem();
                        closest.SetItem(newItem);

                    } else { //attempt to craft item PROB MOVE THIS CODE TO TABLE SCRIPT OR SM

                        ItemInfo item1 = closest.item.GetComponent<Item>().info;
                        ItemInfo item2 = this.item.GetComponent<Item>().info;
                        ItemInfo crafted = CraftingRecipes.Craft(item1,item2);

                        if (crafted) { //create new item and place in slot
                            DestroyItem();
                            closest.DestroyItem();
                            
                            GameObject newItem = Item.CreateItem(crafted);
                            closest.SetItem(newItem);
                        }

                    }

                }
            }

        }

    }

}
