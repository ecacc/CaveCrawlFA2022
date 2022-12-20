using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

      
      public Rigidbody2D rb2D;
      public Animator anim;
      private bool FaceRight = false; // determine which way player is facing.
      public static float runSpeed = 8f;
      public float startSpeed = 4f;
      public static bool isAlive = true;
      //public AudioSource WalkSFX;
      private Vector3 hMove;

      public static bool inLava = false;

      void Start(){
           anim = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
           inLava = false;
      }

      void Update(){
            //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
           hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
           if (isAlive == true){
                  transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
                  if (Input.GetAxis("Horizontal") != 0){
                        anim.SetBool("fireidle", false);
                        if(inLava || PlayerLava.startBlinking) {
                              anim.SetBool("firerun", true);
                        } else {
                              anim.SetBool("firerun", false);
                              anim.SetBool ("run", true);
                        }
                         
                  //       if (!WalkSFX.isPlaying){
                  //             WalkSFX.Play();
                  //      }
                  } else {
                          anim.SetBool("firerun", false);
                          anim.SetBool ("run", false);
                          if(inLava || PlayerLava.startBlinking) {
                              anim.SetBool("fireidle", true);
                          }
                  //      WalkSFX.Stop();
                  }

                  // Turning: Reverse if input is moving the Player right and Player faces left
                 if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
                        playerTurn();
                  }
           }
           //anim.SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));
    }

      void FixedUpdate(){
            //slow down on hills / stops sliding from velocity
            if (hMove.x == 0){
                  rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y) ;
            }
      }

      private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

        // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
      }

      public void OnCollisionEnter2D(Collision2D other) {
            if(other.gameObject.tag == "Lava") {
                  inLava = true;
            }
      }

      public void OnCollisionExit2D(Collision2D other) {
           if(other.gameObject.tag == "Lava") {
                  inLava = false;
            } 
      }
}