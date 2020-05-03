using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FinishedLevelCard : MonoBehaviour {

    RectTransform trans;
    TextMeshPro score;

    public CardState state;
    public int playerScore;

    public Vector3 starThreshholds;
    public GameObject nextLevelButton;
    public GameObject retryLevelButton;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    int scoreCounter = 0;
    float starCounter = 0f;
    public enum CardState {
        HIDDEN,
        SLIDING,
        SCORE,
        STAR,
        BUTTON,
        FINISHED
    }

    void Start() {
        trans = GetComponent<RectTransform>();
        score = GetComponentInChildren<TextMeshPro>();
    }

    void Update() {
        
        if (state == CardState.SLIDING) {
            if (trans.position.y >= 0) {
                state = CardState.SCORE;
            } else {
                trans.position += new Vector3(0, 2, 0);
            }

            
        }
        else if (state == CardState.SCORE) {
            if (scoreCounter == playerScore) {
                state = CardState.STAR;
            } else {
                scoreCounter += (playerScore >= 0 ? 1 : -1);
                score.text = $"SCORE: {scoreCounter.ToString()}";
            }
        }
        else if (state == CardState.STAR) {

            if (playerScore >= starThreshholds.x) {
                star1.SetActive(true);
            }
            if (playerScore >= starThreshholds.y) {
                star2.SetActive(true);
            }
            if (playerScore >= starThreshholds.z) {
                star3.SetActive(true);
            }

            state = CardState.BUTTON;
        }
        else if (state == CardState.BUTTON) {

            if (playerScore >= starThreshholds.x) { //if you get higher than one star u can go to next level
                nextLevelButton.SetActive(true);
            } else {
                retryLevelButton.SetActive(true);
            }

            state = CardState.FINISHED;
        }
        else if (state == CardState.FINISHED) {

            if (Input.GetKeyDown(KeyCode.X)) {
                SoundPlayer.quickStart("Sounds/buttonPress");
                Time.timeScale = 1f;
                if (playerScore >= starThreshholds.x) { //go to next level

                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                } else { //retry level
                    
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
