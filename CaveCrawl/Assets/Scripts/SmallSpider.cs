using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallSpider : MonoBehaviour
{
    public bool down = true;
    public GameObject smallSpider;
    Rigidbody2D myRigidbody;
    Vector3 downVector;
    Vector3 upVector;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = smallSpider.GetComponent<Rigidbody2D>();
        downVector = new Vector3(0, -.08f, 0);
        upVector = new Vector3(0, .08f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(down) {
            myRigidbody.MovePosition(transform.position + downVector);
        } else {
            myRigidbody.MovePosition(transform.position + upVector);
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "ground" || other.gameObject.tag == "Player") {
            Debug.Log("hello");
            down = !down;
        }
    }
}
