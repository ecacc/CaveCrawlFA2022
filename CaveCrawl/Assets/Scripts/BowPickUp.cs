using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPickUp : MonoBehaviour
{ 
  public GameObject objects;
  
  public GameObject BowMessage;

  private bool bMessage = false;
  private double timer = 0;

  // Start is called before the first frame update
  void Start()
  {
    BowMessage.SetActive(false);
    objects.gameObject.GetComponent<AudioSource>().time = 0.1f;
  }

  // Update is called once per frame
  void FixedUpdate() {
    if (bMessage) {
      timer += .005;
      if(timer > 1) {
        BowMessage.SetActive(false);
        bMessage = false;
        timer = 0;
      }
    }
  }

  void OnCollisionEnter2D(Collision2D other) {
    if(other.gameObject.tag == "bow") {
      objects.gameObject.GetComponent<AudioSource>().Play();
      Destroy(other.gameObject);
      bMessage = true;
      BowMessage.SetActive(true);
    }
  }

}
