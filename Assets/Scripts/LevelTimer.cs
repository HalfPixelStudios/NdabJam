using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour {

    public float totalLevelTime;

    float timeleft;

    void Start() {
        timeleft = totalLevelTime;
    }

    void Update() {
        timeleft -= Time.deltaTime;

        if (timeleft < 0) {
            //end level

        }
    }

    void display() {
        int minutes = (int)Mathf.Floor(timeleft/60);
        int seconds = Mathf.RoundToInt(timeleft%60);

        string output = "";
        output += (minutes < 10 ? "0" : "") + minutes.ToString();
        output += ":";
        output += (seconds < 10 ? "0" : "") + seconds.ToString();


    }
}
