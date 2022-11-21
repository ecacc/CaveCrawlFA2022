using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Web : MonoBehaviour
{
    public GameObject web;
    public GameObject newWeb = null;
    public float launchForce;
    public Transform spawnPoint;

    //Timing variables
    public float timeToSpawn;
    private float spawnTimer = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        if (spawnTimer >= timeToSpawn) {
            Shoot();
            spawnTimer = 0f;
        } else {
            spawnTimer += 0.01f;
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
        }
    }


}
