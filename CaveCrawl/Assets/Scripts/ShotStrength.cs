using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotStrength : MonoBehaviour
{
    public GameObject gauge;
    public GameObject meter;
    public Animator anim;

    private Vector3 start;
    private Vector3 end;
    private bool up;
    private int elapsed_frames;
    public int interpolation_frames = 300;
    private bool pause = false;
    // Start is called before the first frame update
    void Start()
    {
        up = true;
        start = meter.transform.position - new Vector3(0, 2, 1);
        end = new Vector3(0, 4, 0);
        end = end + start;
        ShotStrengthInit();
    }
    public void ShotStrengthInit()
    {
        elapsed_frames = 0;
        gauge.transform.position = start;
        up = true;
        anim.SetBool("drawBack", true);
    }

    public void ShotStrengthPause()
    {
        pause = !pause;
        anim.SetBool("shot", pause);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        start = meter.transform.position - new Vector3(0, 2, 1);
        end = new Vector3(0, 4, 0) + start;
        if (!pause)
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
                    anim.SetBool("drawBack", false);
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
                    anim.SetBool("drawBack", true);
                }

            }
        }
    }
}
