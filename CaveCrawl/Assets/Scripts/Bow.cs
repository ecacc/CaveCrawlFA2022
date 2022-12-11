using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject newArrow = null;
    public float maxLaunchForce;
    public Transform shotPoint;
    public GameObject ShotStrengthMeter;
    public GameObject gauge;
    private Vector3 gauge_start;
    Rigidbody2D arrowRB;

    //Timing variables
    public static bool spawn = true;
    public float timeToSpawn;
    private float spawnTimer = 0f;
    public static bool hit = false;
    private bool hasArrow;

    // Start is called before the first frame update
    void Start()
    {
        gauge_start = gauge.transform.position;
        SpawnArrow();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        //if(hasArrow) {
        //    Vector2 arrowPosition = newArrow.transform.position;
        //    Vector2 direction2 = mousePosition - arrowPosition;
        //    newArrow.transform.right = direction2;
        //}

        if(hasArrow) {
            if (Input.GetMouseButtonDown(0) && !PauseMenu.GameisPaused) {
                hasArrow = false;
                ShotStrengthMeter.GetComponent<ShotStrength>().ShotStrengthPause();
                SpawnArrow();
                Vector2 arrowPosition = newArrow.transform.position;
                Vector2 direction2 = mousePosition - arrowPosition;
                newArrow.transform.right = direction2;
                Shoot();
            } 
        } else if (!hasArrow) {
                if (spawnTimer >= timeToSpawn) {
                    Debug.Log("Before unpause call: " + spawnTimer);
                    ShotStrengthMeter.GetComponent<ShotStrength>().ShotStrengthPause();
                    ShotStrengthMeter.GetComponent<ShotStrength>().ShotStrengthInit();
                    //SpawnArrow();
                    hasArrow = true;
                    spawnTimer = 0f;
                } else {
                    spawnTimer += .01f;
                }
        }
    }

    void SpawnArrow()
    {
        hasArrow = true;
        newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        arrowRB = newArrow.GetComponent<Rigidbody2D>();
        arrowRB.constraints = RigidbodyConstraints2D.FreezePosition;
        newArrow.SetActive(false);

    }

    void Shoot()
    {
        hasArrow = false;
        Vector3 gauge_curr = gauge.transform.position;
        float launchForce = ((gauge_curr.y - gauge_start.y) / 4) * maxLaunchForce;
        newArrow.SetActive(true);
        arrowRB.constraints = RigidbodyConstraints2D.None;
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}
