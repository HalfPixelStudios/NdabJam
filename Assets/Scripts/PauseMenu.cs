using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused;
    public GameObject unpausedUI;
    public GameObject pausedUI;

    private void Start() {
        unpausedUI.SetActive(true);
        pausedUI.SetActive(false);
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseMenu.isPaused = !isPaused;

            //stop time
            if (isPaused) {
                Time.timeScale = 0f;
            } else {
                Time.timeScale = 1f;
            }

            //update ui
            unpausedUI.SetActive(!isPaused);
            pausedUI.SetActive(isPaused);

            //pitch down music
            AudioSource music = GameObject.Find("Music").GetComponent<AudioSource>();
            music.pitch = isPaused ? 0.8f : 1;
        }

    }

}
