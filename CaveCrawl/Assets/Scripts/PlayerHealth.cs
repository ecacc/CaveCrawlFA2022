using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject halfheart1;
    public GameObject halfheart2;
    public GameObject halfheart3;
    public GameObject light;

    public static float health = 1f;

    // Start is called before the first frame update
    void Start()
    {
        health = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (light.GetComponent<UnityEngine.Rendering.Universal.Light2D>().intensity <= 0.01) {
            health -= .001f;
        }
        if (.7f <= health && health <= .85f) {
            heart2.SetActive(false);
            halfheart1.SetActive(true);
        } else if (.55f <=  health && health <= .7f) {
            halfheart1.SetActive(false);
        } else if(.4f <= health && health <= .55f) {
            heart3.SetActive(false);
            halfheart2.SetActive(true);
        } else if (.25f <= health && health <= .4f) {
            halfheart2.SetActive(false);
        } else if (.1 <= health && health <= .25f) {
            heart1.SetActive(false);
            halfheart3.SetActive(true);
        } else if (health <= .1f) {
            halfheart3.SetActive(false);
        }
        
    }
}
