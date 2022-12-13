using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBossFight : MonoBehaviour
{
    public GameObject player;
    public float camSpeed = 4.0f;
    private bool follow_player;
    private Camera fightCam;

    void Start()
    {
        follow_player = true;
        fightCam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (follow_player)
        {
            Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)player.transform.position, camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
        }
        else
        {
            Vector2 pos = Vector2.Lerp((Vector2)transform.position, new Vector2(0, 0), camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            fightCam.orthographicSize = fightCam.orthographicSize + 1 * Time.deltaTime;
            if (fightCam.orthographicSize > 11)
            {
                fightCam.orthographicSize = 11; // Max size
            }
        }
        
    }

    public void FightCam()
    {
        follow_player = false; 
    }
}
