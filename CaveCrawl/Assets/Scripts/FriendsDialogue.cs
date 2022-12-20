using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendsDialogue : MonoBehaviour
{
    public GameObject objects;
    public GameObject GoblinMessage;
    public GameObject FriendsMessage;
    public GameObject EndBlock;

    private bool bMessage = false;
    private double timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        FriendsMessage.SetActive(false);
        EndBlock.SetActive(true);
        objects.gameObject.GetComponent<AudioSource>().time = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bMessage)
        {
            timer += .005;
            if (timer > .6)
            {
                EndBlock.SetActive(false);
            }
            if (timer > 1)
            {
                FriendsMessage.SetActive(false);
                bMessage = false;
                timer = 0;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!GoblinMessage.activeSelf)
        {
            if (other.gameObject.name == "FriendTrigger")
            {
                objects.gameObject.GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                bMessage = true;
                FriendsMessage.SetActive(true);
            }
        }
    }
}
