using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject DoorOpen;

    void OnCollisionEnter2D(Collision2D other){
          if (other.gameObject.tag == "Player" && DoorOpen.activeSelf) {
            if (DeathScreen.currlevel == 1) {
                 SceneManager.LoadSceneAsync("Level2"); 
            } else if (DeathScreen.currlevel == 2) {
                 SceneManager.LoadSceneAsync("Level3"); 
            } else if (DeathScreen.currlevel == 3) {
                 SceneManager.LoadSceneAsync("Level4"); 
            } else if (DeathScreen.currlevel == 4) {
                 SceneManager.LoadSceneAsync("SampleScene"); 
            } else {
                 SceneManager.LoadSceneAsync("SpiderFight");
            }
          }
     }


}
