using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDialogue : MonoBehaviour
{
    public GameObject objects;

    public GameObject GoblinMessage;
    public GameObject GoblinBlock;

    private bool bMessage = false;
    private double timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        GoblinBlock.SetActive(true);
        GoblinMessage.SetActive(false);
        objects.gameObject.GetComponent<AudioSource>().time = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bMessage)
        {
            timer += .005;
            if (timer > 1)
            {
                GoblinMessage.SetActive(false);
                bMessage = false;
                timer = 0;
                GoblinBlock.SetActive(false);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "GoblinTrigger")
        {
            objects.gameObject.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            bMessage = true;
            GoblinMessage.SetActive(true);
            
        }
    }

}
