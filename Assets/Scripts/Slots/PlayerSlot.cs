using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GlobalContainer;

public class PlayerSlot : Slot {

    public float pickup_radius;


    private void Start() {
        base.Start();
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
                closest.Interact(this);
            }

        }

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, pickup_radius);
    }

}
