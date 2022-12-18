using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Mushroom : MonoBehaviour
{
    
     public GameObject light;

     void Update() {
      if(!(NoteOpen.noteShow)) {
        if (light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity >= 0.01) {
          light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= .0001f;
        }
      }
     }

     void OnCollisionEnter2D(Collision2D other) {
          if (other.gameObject.tag == "mushroom"){
               Destroy(other.gameObject);
               light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity = 1;
          }
     }

}

