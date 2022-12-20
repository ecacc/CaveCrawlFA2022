using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFightMove : MonoBehaviour
{
    public float runSpeed = 8f;
    private Vector3 hMove;
    public GameObject CameraBossFight;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("Walking", true);
        }else
        {
            anim.SetBool("Walking", false);
        }
        transform.position = transform.position + hMove * runSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BossFightTrigger")
        {
            other.gameObject.SetActive(false);
            CameraBossFight.GetComponent<CameraBossFight>().FightCam();
        }
    }

    
}
