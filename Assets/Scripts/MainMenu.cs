using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private void Start() {

        
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.E)) {
            //also play a lil sound and make a transition
            SoundPlayer.quickStart("Sounds/startGame");

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);

            
        }
    }
}
