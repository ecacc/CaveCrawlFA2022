using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class NoteOpen : MonoBehaviour
{
     public GameObject objects;

     public GameObject noteUI;
     public GameObject inventory;
     public GameObject hearts;

     public static bool noteShow = false;

     public static bool GameisPaused = false;


     void Start() {
      noteUI.SetActive(false);
      inventory.SetActive(true);
      hearts.SetActive(true);
      objects.gameObject.GetComponent<AudioSource>().time = 0.1f;
     }

     void Update() {
      if(noteShow) {
          Pause();
      }
     }

     void OnCollisionEnter2D(Collision2D other) {
       if (other.gameObject.tag == "note") {
          objects.gameObject.GetComponent<AudioSource>().Play();
          Destroy(other.gameObject);
          noteShow = true;
       }
     }

     void Pause() {
      noteUI.SetActive(true);
      inventory.SetActive(false);
      hearts.SetActive(false);
      Time.timeScale = 0f;
      GameisPaused = true;
     }

     public void Resume() {
      noteUI.SetActive(false);
      inventory.SetActive(true);
      hearts.SetActive(true);
      Time.timeScale = 1f;
      noteShow = false;
      GameisPaused = false;
     }
}

