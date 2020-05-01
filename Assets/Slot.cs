using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private GameObject item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("slot"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (item == null)
                {
                    item = other.gameObject.GetComponent<Slot>().item;
                }else if (other.gameObject.GetComponent<Slot>().item == null)
                {
                    item = null;
                }
                
            }
        }
    }
}
