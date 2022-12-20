using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public static bool beginning = true;
    // Start is called before the first frame update
    void Start()
    {
        if(beginning) {
            DontDestroyOnLoad(this.gameObject);
        } else {
            this.GetComponent<AudioSource>().Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
