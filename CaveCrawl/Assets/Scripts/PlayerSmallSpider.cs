using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmallSpider : MonoBehaviour
{
    public GameObject light;

    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public bool startBlinking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(startBlinking == true) {
            SpriteBlinkingEffect();
            PlayerHealth.health -= .005f;
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "smallspider") {
            startBlinking = true;
            // if (light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity >= 0.01) {
            //    light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= .1f;
            // }
        }
    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if(spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
              startBlinking = false;
             spriteBlinkingTotalTimer = 0.0f;
             this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   // according to 
                      //your sprite
             return;
          }
     
     spriteBlinkingTimer += Time.deltaTime;
     if(spriteBlinkingTimer >= spriteBlinkingMiniDuration)
     {
         spriteBlinkingTimer = 0.0f;
         if (this.gameObject.GetComponent<SpriteRenderer> ().enabled == true) {
             this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;  //make changes
         } else {
             this.gameObject.GetComponent<SpriteRenderer> ().enabled = true;   //make changes
         }
     }
    }
}
