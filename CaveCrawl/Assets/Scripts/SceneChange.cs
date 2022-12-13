using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject DoorOpen;

    void OnCollisionEnter2D(Collision2D other){
          if (other.gameObject.tag == "Player" && DoorOpen.activeSelf) {
            if (DeathScreen.currlevel == 0) {
              SceneManager.LoadSceneAsync("SampleScene");
            } else {
              SceneManager.LoadSceneAsync("SpiderFight");
            }
          }
     }


}
