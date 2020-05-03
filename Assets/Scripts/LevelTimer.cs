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

    float flashTime = 0;

    void Start() {
        text = GetComponent<TextMeshProUGUI>();

        timeleft = totalLevelTime;
    }

    void Update() {

        timeleft -= Time.deltaTime;
        display();
        if (timeleft < 0) {
            //end level
            Time.timeScale = 0f;

            //calculate total score
            int posScore = 0;
            int negScore = 0;
            DeliverySlot[] bins = FindObjectsOfType<DeliverySlot>();

            foreach(var bin in bins) {
                posScore += bin.posScore;
                negScore += bin.negScore;

            }

            //bring up a screen to show score
            Debug.Log($"{posScore},{negScore}");


        }
    }

    void display() {

        if (timeleft < 0) { return; }

        int minutes = (int)Mathf.Floor(timeleft/60);
        int seconds = (int)Mathf.Floor(timeleft%60);

        string output = "";
        output += (minutes < 10 ? "0" : "") + minutes.ToString();
        output += ":";
        output += (seconds < 10 ? "0" : "") + seconds.ToString();

        text.text = output;

        //if there is little time left, make text flash red
        if (minutes == 0 && seconds < 10) {
            text.color = new Color(1, 0, 0, 1) + new Color(0, 1, 1, 0) * 0.5f * (Mathf.Cos(flashTime) + 0.5f);
            flashTime += 5*Time.deltaTime;
            
        }
    }
}
