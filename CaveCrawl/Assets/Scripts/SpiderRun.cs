using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SpiderRun : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject spider;
    public Transform leftBound;
    public Transform rightBound;
    public GameObject spiderheart1;
    public GameObject CameraBossFight;
    public float moveSpeed = 2f;
    private bool goingLeft;
    private float pos;
    
    void Start()
    {
        goingLeft = true;
        pos = transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (spiderheart1.activeSelf)
        {
            if (goingLeft)
            {
                //Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)leftBound.position, moveSpeed * Time.fixedDeltaTime);
                pos = pos - (.1f * moveSpeed);
                //transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
                transform.position = new Vector3(pos, transform.position.y, transform.position.z);
            }
            else
            {
                //Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)rightBound.position, moveSpeed * Time.fixedDeltaTime);
                pos = pos + (.1f * moveSpeed);
                //transform.position = new Vector3(pos.x, transform.position.y, transform.position.z);
                transform.position = new Vector3(pos, transform.position.y, transform.position.z);
            }
            if (transform.position.x <= leftBound.position.x)
            {
                goingLeft = false;
                pos = leftBound.position.x;
            }
            else if (transform.position.x >= rightBound.position.x)
            {
                goingLeft = true;
                pos = rightBound.position.x;
            }
        }
        else
        {
            Collider2D col = GetComponent<Collider2D>();
            col.enabled = false;
            pos = transform.position.y + (0.1f * moveSpeed);
            if (pos < 10)
            {
                transform.position = new Vector3(transform.position.x, pos, transform.position.z);
            }
            else
            {
                this.gameObject.SetActive(false);

                CameraBossFight.GetComponent<CameraBossFight>().FightCam();
            }
        }
    }
}
