using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowHit : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other){ 
        if(other.gameObject.tag == "arrow") {
            Destroy(other.gameObject);
            Bow.hit = true;
        }
    }
}
