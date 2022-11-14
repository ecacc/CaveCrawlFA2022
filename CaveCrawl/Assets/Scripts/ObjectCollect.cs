using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
    
     public GameObject CB;
     public GameObject GC;
     public GameObject HS;
     public GameObject WB;
     public GameObject light;
     public static bool note = false;
     public GameObject note1;
     public GameObject inventory;


     void Start(){
      note1.SetActive(false);
      inventory.SetActive(true);
     }

     void Update(){
      if(!note) {
        light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= .0001f;
      } else {
        if(Input.GetKeyDown(KeyCode.E)) {
          note = false;
          note1.SetActive(false);
          inventory.SetActive(true);
        } else {
          note1.SetActive(true);
          inventory.SetActive(false);
        }
      }
     }

     void OnCollisionEnter2D(Collision2D other){
          if (other.gameObject.layer == 9){
               Destroy(other.gameObject);
          } 
          if (other.gameObject.tag == "ChumBucket") {
            CB.SetActive(true);
          } else if (other.gameObject.tag == "GoldCoin") {
            GC.SetActive(true);
          } else if (other.gameObject.tag == "HandSanitizer") {
            HS.SetActive(true);
          } else if (other.gameObject.tag == "WaterBucket"){
            WB.SetActive(true);
          } else if (other.gameObject.tag == "mushroom") {
            light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
          } else if (other.gameObject.tag == "note") {
            note = true;
          }
     }
}
