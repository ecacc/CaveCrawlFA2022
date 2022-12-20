using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBossFight : MonoBehaviour
{
    public GameObject player;
    public float camSpeed = 4.0f;
    private bool follow_player;
    private Camera fightCam;
    private float start_cam_size;

    void Start()
    {
        follow_player = true;
        fightCam = GetComponent<Camera>();
        start_cam_size = fightCam.orthographicSize;
    }

    void FixedUpdate()
    {
        if (follow_player)
        {
            Vector2 pos = Vector2.Lerp((Vector2)transform.position, (Vector2)player.transform.position, camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            fightCam.orthographicSize = fightCam.orthographicSize - 2 * Time.deltaTime;
            if (fightCam.orthographicSize < start_cam_size)
            {
                fightCam.orthographicSize = start_cam_size; // Max size
            }
        }
        else
        {
            Vector2 pos = Vector2.Lerp((Vector2)transform.position, new Vector2(0, 3), camSpeed * Time.fixedDeltaTime);
            transform.position = new Vector3(pos.x, pos.y, transform.position.z);
            fightCam.orthographicSize = fightCam.orthographicSize + 2 * Time.deltaTime;
            if (fightCam.orthographicSize > 15)
            {
                fightCam.orthographicSize = 15; // Max size
            }
        }
        
    }

    public void FightCam()
    {
        Debug.Log("fight cam call");
        follow_player = !follow_player; 
        
    }
}
