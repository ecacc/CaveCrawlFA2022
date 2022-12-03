using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStrength : MonoBehaviour
{
    public GameObject gauge;
    public GameObject meter;

    private Vector3 start;
    private Vector3 end;
    private float distance = 0f;
    private bool up;
    private int elapsed_frames = 0;
    public int interpolation_frames = 300;
    // Start is called before the first frame update
    void Start()
    {
        up = true;
        start = gauge.transform.position;
        end = new Vector3(0, 4, 0);
        end = end + start;
    }

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            float interpolationRatio = (float)elapsed_frames / interpolation_frames;

            Vector3 interpolatedPosition = Vector3.Lerp(start, end, interpolationRatio);

            elapsed_frames = (elapsed_frames + 1) % (interpolation_frames + 1);
            gauge.transform.position = interpolatedPosition;
            if (elapsed_frames == 0)
            {
                up = false;
            }

        }
        else
        {
            float interpolationRatio = (float)elapsed_frames / interpolation_frames;

            Vector3 interpolatedPosition = Vector3.Lerp(end, start, interpolationRatio);

            elapsed_frames = (elapsed_frames + 1) % (interpolation_frames + 1);
            gauge.transform.position = interpolatedPosition;
            if (elapsed_frames == 0)
            {
                up = true;
            }

        }
    }
}
