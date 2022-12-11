using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArms : MonoBehaviour
{
    public Transform arm_pivot;
    public Camera m_camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookPoint = m_camera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 distanceVector = lookPoint - arm_pivot.position;
        float angle = Mathf.Atan2(distanceVector.y, distanceVector.x) * Mathf.Rad2Deg;
        arm_pivot.rotation = Quaternion.Lerp(arm_pivot.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * 18.3f);
    }
}
