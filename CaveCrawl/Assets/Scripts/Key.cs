using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Key : MonoBehaviour
{
     public GameObject keyUI;
     public GameObject DoorOpen;
     public GameObject KeyMessage;

     private bool kMessage = false;
     private double timer = 0;


     void Start() {
      keyUI.SetActive(false);
      KeyMessage.SetActive(false);
     }

     void FixedUpdate(){
      if (kMessage) {
        timer += .005;
        if(timer > 1) {
          KeyMessage.SetActive(false);
          kMessage = false;
          timer = 0;
        }
      }
     }

     void OnCollisionEnter2D(Collision2D other) {
          if (other.gameObject.tag == "Key"){
               Destroy(other.gameObject);
               keyUI.SetActive(true);
          } 
          if (other.gameObject.tag == "Door") {
            if(keyUI.activeSelf) {
              Destroy(other.gameObject);
              DoorOpen.SetActive(true);
            } else {
              KeyMessage.SetActive(true);
              kMessage = true;
            }
          }
     }

}

