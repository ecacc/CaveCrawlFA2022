using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{

    // Update is called once per frame
    void Update(){
    }

    public void Restart() {
        if (DeathScreen.currlevel == 1) {
           SceneManager.LoadSceneAsync("Level1"); 
        } else if (DeathScreen.currlevel == 2) {
            SceneManager.LoadSceneAsync("Level2"); 
        } else if (DeathScreen.currlevel == 5) {
            SceneManager.LoadSceneAsync("SampleScene");
        } else if (DeathScreen.currlevel == 6) {
           SceneManager.LoadSceneAsync("SpiderFight"); 
        } else {
            SceneManager.LoadSceneAsync("StartPage");
        }
    }


    public void QuitGame() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
      }
}
