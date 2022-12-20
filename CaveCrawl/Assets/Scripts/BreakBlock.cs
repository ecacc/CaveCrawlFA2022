using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBlock : MonoBehaviour
{
    public GameObject spiderLastHeart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!spiderLastHeart.activeSelf) {
            Destroy(this.gameObject);
        }
    }
}
