using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour {
    public GameObject item;

    protected void Start() {
        CircleCollider2D col = gameObject.AddComponent<CircleCollider2D>();
        col.radius = 0.05f;
    }


    public void SetItem(GameObject item) {
        this.item = item;
        item.transform.position = transform.position;
        item.transform.parent = transform;
    }

    public GameObject RemoveItem() {
        GameObject removed = this.item;
        this.item = null;
        return removed;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
