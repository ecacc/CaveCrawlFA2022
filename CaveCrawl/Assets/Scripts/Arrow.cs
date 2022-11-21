using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    Rigidbody2D rb;


      void Start()
      {
        rb = GetComponent<Rigidbody2D>();
      }

      void Update ()
      {
        if(Bow.spawn) {
          trackMovement();
        }
      }

      void trackMovement()
      {
        Vector2 direction = rb.velocity;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
      }
}
