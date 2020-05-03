using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class LevelTimer : MonoBehaviour {

    public float totalLevelTime;

    float timeleft;
    TextMeshProUGUI text;

    void Start() {
        text = GetComponent<TextMeshProUGUI>();

        timeleft = totalLevelTime;
    }

    void Update() {

        timeleft -= Time.deltaTime;
        display();
        if (timeleft < 0) {
            //end level

        }
    }

    void display() {
        int minutes = (int)Mathf.Floor(timeleft/60);
        int seconds = (int)Mathf.Floor(timeleft%60);

        string output = "";
        output += (minutes < 10 ? "0" : "") + minutes.ToString();
        output += ":";
        output += (seconds < 10 ? "0" : "") + seconds.ToString();

        text.text = output;
    }
}
