using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightLava : MonoBehaviour
{
    public GameObject light;
    public SpriteRenderer sprite;

    public float spriteBlinkingTimer = 0.0f;
    public float spriteBlinkingMiniDuration = 0.1f;
    public float spriteBlinkingTotalTimer = 0.0f;
    public float spriteBlinkingTotalDuration = 1.0f;
    public static bool startBlinking = false;

    // Start is called before the first frame update
    void Start()
    {
        startBlinking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (startBlinking == true)
        {
            SpriteBlinkingEffect();
            PlayerHealth.health -= .005f;
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Lava")
        {
            Debug.Log("Blinking?");
            startBlinking = true;
            GetComponent<Web>().decreaseHealth();
            // if (light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity >= 0.01) {
            //    light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= .1f;
            // }
        }
        else if (other.gameObject.tag == "web")
        {
            Debug.Log("Blinking?");
            startBlinking = true;
            // if (light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity >= 0.01) {
            //    light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity -= .1f;
            // }
        }
    }

    private void SpriteBlinkingEffect()
    {
        spriteBlinkingTotalTimer += Time.deltaTime;
        if (spriteBlinkingTotalTimer >= spriteBlinkingTotalDuration)
        {
            startBlinking = false;
            spriteBlinkingTotalTimer = 0.0f;
            sprite.enabled = true;   // according to 
                                                                             //your sprite
            return;
        }

        spriteBlinkingTimer += Time.deltaTime;
        if (spriteBlinkingTimer >= spriteBlinkingMiniDuration)
        {
            spriteBlinkingTimer = 0.0f;
            if (sprite.enabled == true)
            {
                sprite.enabled = false;  //make changes
            }
            else
            {
                sprite.enabled = true;   //make changes
            }
        }
    }
}
