using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    public int spiderHealth = 3;
    public GameObject spiderHeart1;
    public GameObject spiderHeart2;
    public GameObject spiderHeart3;
    public GameObject inventory;
    public GameObject CameraBossFight;
    public Animator anim;
    public AudioSource spiderSound;
    public GameObject pauseMenu;

    void Start()
    {
        spiderSound.Play();
        spiderHeart1.SetActive(true);
        spiderHeart2.SetActive(true);
        spiderHeart3.SetActive(true);
        inventory.SetActive(false);
    }

    void FixedUpdate()
    {
        if(pauseMenu.activeSelf) {
            spiderSound.Stop();
        } else if(!pauseMenu.activeSelf && !spiderSound.isPlaying && spiderHeart1.activeSelf) {
            spiderSound.Play();
        }
        if(spiderHealth == 2) {
            spiderHeart3.SetActive(false);
        } else if(spiderHealth == 1) {
            spiderHeart2.SetActive(false);
        } else if(spiderHealth == 0) {
           spiderHeart1.SetActive(false);
            inventory.SetActive(true);
            spiderSound.Stop();
            anim.SetTrigger("Dead");
        }
    }

    void OnCollisionEnter2D(Collision2D other){ 
        if(other.gameObject.tag == "arrow") {
            Destroy(other.gameObject);
            spiderHealth -= 1;
            Bow.hit = true;
        }
    }
}
