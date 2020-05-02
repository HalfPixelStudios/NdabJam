using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ItemInfo : ScriptableObject {

    public Sprite sprite;
    public int correctPoints = 100;
    public int incorrectPoints = -100;
}
