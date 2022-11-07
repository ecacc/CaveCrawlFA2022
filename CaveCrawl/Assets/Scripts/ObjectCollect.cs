using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollect : MonoBehaviour
{
    
     public GameObject CB;
     public GameObject GC;
     public GameObject HS;
     public GameObject WB;


     void Start(){
     }

     void FixedUpdate(){
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
          }
     }
}
