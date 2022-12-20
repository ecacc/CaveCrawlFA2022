using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetGrappling : MonoBehaviour
{
    public GameObject player;
    public GameObject GunPivot;

    public GameObject GrapplingMessage;

    private bool gMessage = false;
    private double timer = 0;

    // Start is called before the first frame update
    void Start()
    {
       player.GetComponent<SpringJoint2D>().enabled = false;
       GunPivot.SetActive(false);
       GrapplingMessage.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate() {
      if (gMessage) {
        if (NoteOpen.noteShow) {
            timer = 1.5;
        } else {
            timer += .005;
        }
        if(timer > 1) {
          GrapplingMessage.SetActive(false);
          gMessage = false;
          timer = 0;
        }
      }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "GrapplingHook") {
            Destroy(other.gameObject);
            //player.GetComponent<SpringJoint2D>().enabled = true;
            GunPivot.SetActive(true);
            gMessage = true;
            GrapplingMessage.SetActive(true);
        }
    }
}
