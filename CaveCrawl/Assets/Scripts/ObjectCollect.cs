using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class ObjectCollect : MonoBehaviour
{
    
     public GameObject GoldKey;
     public GameObject GreenKey;
     public GameObject BlueKey;
     public GameObject RedKey;
     public GameObject PurpleKey;
     public GameObject SkullKey;
     public GameObject light;
     public static bool note = false;
     public GameObject note1;
     public GameObject inventory;
     public GameObject DoorOpen;
     public GameObject KeyMessage;
     public bool kMessage = false;

     public double timer = 0;

     public int numKeys = 0;

     public static bool GameisPaused = false;


     void Start(){
      note1.SetActive(false);
      inventory.SetActive(true);
     }

     void Update(){
      if(!note) {
        if (light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity >= 0.01) {
          light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= .0002f;
        }
      } else {
        if(Input.GetKeyDown(KeyCode.Return)) {
          Resume();
        } else {
          Pause();
        }
      }
      if (kMessage) {
        timer += .001;
        if(timer > 1) {
          KeyMessage.SetActive(false);
          kMessage = false;
          timer = 0;
        }
      }
     }

     void OnCollisionEnter2D(Collision2D other){
          if (other.gameObject.layer == 9){
               Destroy(other.gameObject);
          } 
          if (other.gameObject.tag == "Key") {
            string name = other.gameObject.name;
            if (name == "GoldKey") {
              numKeys += 1;
              GoldKey.SetActive(true);
            } else if (name == "GreenKey") {
              numKeys += 1;
              GreenKey.SetActive(true);
            } else if (name == "BlueKey") {
              numKeys += 1;
              BlueKey.SetActive(true);
            } else if (name == "RedKey") {
              numKeys += 1;
              RedKey.SetActive(true);
            } else if (name == "PurpleKey") {
              numKeys += 1;
              PurpleKey.SetActive(true);
            } else {
              numKeys += 1;
              SkullKey.SetActive(true);
            }
          } else if (other.gameObject.tag == "mushroom") {
            light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
          } else if (other.gameObject.tag == "note") {
            note = true;
          }
          if (other.gameObject.tag == "Door") {
            if(numKeys == 6) {
              Destroy(other.gameObject);
              DoorOpen.SetActive(true);
            } else {
              KeyMessage.SetActive(true);
              kMessage = true;
            }
          }
     }


     void Pause(){
      note1.SetActive(true);
      inventory.SetActive(false);
      Time.timeScale = 0f;
      GameisPaused = true;
     }

     public void Resume(){
      note1.SetActive(false);
      inventory.SetActive(true);
      Time.timeScale = 1f;
      note = false;
      GameisPaused = false;
     }



}
