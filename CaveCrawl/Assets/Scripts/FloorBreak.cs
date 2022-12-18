using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBreak : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FloorDestroy"))
        {
            Rigidbody2D rb = this.gameObject.GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
            this.GetComponent<Collider2D>().enabled = false;
            Debug.Log("destroy");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("FloorDelete"))
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            anim.SetTrigger("Break");
        }
    }
}
