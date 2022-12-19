using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class KeyWiggle : MonoBehaviour
{
    private Vector3 start;
    private Rigidbody2D rb;

    public float speed = 0.1f;
    public int height;
    private bool up;
    private int cnt;
    void Start()
    {
        up = true;
        height = 1;
        cnt = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (up)
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + speed, this.gameObject.transform.position.z);
            cnt++;
            if (cnt * speed >= height)
            {
                up = false;
            }
        }
        else
        {
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - speed, this.gameObject.transform.position.z);
            cnt--;
            if (cnt == 0)
            {
                up = true;
            }
        }
    }
}
