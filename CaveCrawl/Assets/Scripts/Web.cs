using System.Collections;
using System.Collections.Generic;
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

    //Timing variables
    public float timeToSpawn;
    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        playerHeart1.SetActive(true);
        playerHeart2.SetActive(true);
        playerHeart3.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
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
    }

    void Shoot()
    {
        newWeb = Instantiate(web, spawnPoint.position, spawnPoint.rotation);
        newWeb.GetComponent<Rigidbody2D>().velocity = -newWeb.gameObject.transform.right * launchForce;
    }


    void OnCollisionEnter2D(Collision2D other){ 
        if(other.gameObject.tag == "web") {
            Destroy(other.gameObject);
            playerHealth -= 1;
        }
    }


}
