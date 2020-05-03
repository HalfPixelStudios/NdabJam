using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliverySlot : Slot {

    public List<ItemInfo> acceptable;

    public List<ItemInfo> deposited;

    public int posScore = 0;
    public int negScore = 0;
    

    void Start() {
        base.Start();

        hideWhenHeld = true;
    }

    void Update() {
        if (item != null) { //if an item is deposited, save it's item info and then destroy it
            ItemInfo info = item.GetComponent<Item>().info;
            DestroyItem();
            deposited.Add(info);

            //play some sounds to tell user if the delivery was a success
            if (acceptable.Contains(info)) {
                posScore += info.correctPoints;

                if (!muteEffects) { SoundPlayer.quickStart("Sounds/depositSuccess"); }

                

                Instantiate(Resources.Load("Particles/deliverySuccessParticle"), transform.position, Quaternion.identity);
                
            } else {
                negScore += info.incorrectPoints;
                SoundPlayer.quickStart("Sounds/depositFail");

                Instantiate(Resources.Load("Particles/deliveryFailParticle"), transform.position, Quaternion.identity);
            }
        }
    }

    /*
    public int CalculateScore() {
        int score = 0;

        foreach (var info in deposited) {

            if (acceptable.Contains(info)) { //if correct
                score += info.correctPoints;
            } else {
                score += info.incorrectPoints;
            }
        }
        return score;
    }
    */

    
}
