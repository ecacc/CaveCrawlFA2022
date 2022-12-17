using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPickUp : MonoBehaviour
{ 
    public GameObject BowMessage;

    private bool bMessage = false;
    private double timer = 0;

    // Start is called before the first frame update
    void Start()
    {
       BowMessage.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
      if (bMessage) {
            timer += .001;
        if(timer > 1) {
          BowMessage.SetActive(false);
          bMessage = false;
          timer = 0;
        }
      }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "bow") {
            Destroy(other.gameObject);
            bMessage = true;
            BowMessage.SetActive(true);
        }
    }
}
