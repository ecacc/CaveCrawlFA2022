using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMeterMovement : MonoBehaviour
{
    private Transform target;
    public float move_speed = 4.0f;
    private Transform meter_transform;
    private Vector3 distance;

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
        meter_transform = transform;
        distance = meter_transform.position - target.position;


    }

    void FixedUpdate()
    {
        Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)target.transform.position + (Vector2) distance, move_speed * Time.fixedDeltaTime);
        transform.position = new Vector3(pos.x, pos.y, transform.position.z);
    }
}
