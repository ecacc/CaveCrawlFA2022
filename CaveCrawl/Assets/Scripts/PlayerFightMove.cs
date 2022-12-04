using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightMove : MonoBehaviour
{
    public static float runSpeed = 8f;
    private Vector3 hMove;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
    }
}
