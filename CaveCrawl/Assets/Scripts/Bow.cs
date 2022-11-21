using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrow;
    public GameObject newArrow = null;
    public float launchForce;
    public Transform shotPoint;

    Rigidbody2D arrowRB;

    //Timing variables
    public static bool spawn = true;
    public float timeToSpawn;
    private float spawnTimer = 0f;
    public static bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        SpawnArrow();
        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 bowPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - bowPosition;
        transform.right = direction;

        if(!spawn) {
            Vector2 arrowPosition = newArrow.transform.position;
            Vector2 direction2 = mousePosition - arrowPosition;
            newArrow.transform.right = direction2;
        }

        if(!spawn & Input.GetMouseButtonDown(0)) {
                spawn = true;
                Shoot();
            } else if (spawn == true) {
                if (spawnTimer >= timeToSpawn) {
                    SpawnArrow();
                    spawn = false;
                    spawnTimer = 0f;
                } else {
                    spawnTimer += 0.01f;
                }

            }
    }

    void SpawnArrow()
    {
        newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
        arrowRB = newArrow.GetComponent<Rigidbody2D>();
        arrowRB.constraints = RigidbodyConstraints2D.FreezePosition;
    }

    void Shoot()
    {
        arrowRB.constraints = RigidbodyConstraints2D.None;
        newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }
}
