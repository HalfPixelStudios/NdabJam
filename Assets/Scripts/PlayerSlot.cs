using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlot : Slot
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("slot"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (item == null)
                {
                    item = other.gameObject.GetComponent<Slot>().item;
                    other.gameObject.GetComponent<Slot>().item = null;
                }else if (other.gameObject.GetComponent<Slot>().item == null)
                {
                    other.GetComponent<Slot>().item = item;
                    item = null;
                    
                }
                
            }
        }
    }
}
