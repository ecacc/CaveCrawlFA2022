using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMix : MonoBehaviour
{
    public GameObject TrailMessage;

    private bool tMessage = false;
    private double timer = 0;

    void Start() {
      TrailMessage.SetActive(false);
    }

    void Update(){
      if (tMessage) {
        timer += .001;
        if(timer > 1) {
          TrailMessage.SetActive(false);
          tMessage = false;
          timer = 0;
        }
      }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "trailmix") {
            Destroy(other.gameObject);
            PlayerHealth.health = 1f;
            TrailMessage.SetActive(true);
            tMessage = true;
        }
    }
}
