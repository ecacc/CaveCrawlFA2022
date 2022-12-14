using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Web : MonoBehaviour
{
    public GameObject web;
    public GameObject newWeb = null;
    public float launchForce;
    public Transform spawnPoint;

    public int playerHealth = 6;
    public GameObject playerHeart1;
    public GameObject playerHeart2;
    public GameObject playerHeart3;
    public GameObject spiderheart1;

    //Timing variables
    public float timeToSpawn;
    private float spawnTimer = 0f;
    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        playerHeart1.SetActive(true);
        playerHeart2.SetActive(true);
        playerHeart3.SetActive(true);
        active = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
        if (active)
        { 
            if (spawnTimer >= timeToSpawn) {
                Shoot();
                spawnTimer = 0f;
            } else {
                spawnTimer += 0.01f;
            }

            if(playerHealth == 4) {
                playerHeart3.SetActive(false);
            } else if(playerHealth == 2) {
                playerHeart2.SetActive(false);
            } else if(playerHealth == 0) {
               playerHeart1.SetActive(false); 
            }
            if(spiderheart1.activeSelf == false)
            {
                active = false;
            }
        }
    }

    void Shoot()
    {
        newWeb = Instantiate(web, spawnPoint.position, spawnPoint.rotation);
        //newWeb.GetComponent<Rigidbody2D>().velocity = -newWeb.gameObject.transform.right * launchForce;
        Vector3 x = -newWeb.gameObject.transform.right * launchForce;
        float randy = (float)Random.Range(0, 3);
        if (randy != 2)
        {
            randy = randy+ 0.25f;
        }
        Vector3 y = new Vector3(0, randy * 0.5f * launchForce, 0);
        newWeb.GetComponent<Rigidbody2D>().velocity = x + y;
    }


    void OnCollisionEnter2D(Collision2D other){ 
        if(other.gameObject.tag == "web") {
            Destroy(other.gameObject);
            decreaseHealth();
        }
    }

    public void decreaseHealth()
    {
        playerHealth -= 1;
    }

}
