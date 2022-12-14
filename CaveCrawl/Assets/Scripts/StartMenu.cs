using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public GameObject hover;
    public GameObject mouse;
    public bool play = false;
    // Start is called before the first frame update
    void Start()
    {
        hover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        mouse.transform.position = Input.mousePosition + new Vector3(0f, 0f, 1f);
        if(play && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadSceneAsync("Level1");
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        hover.SetActive(true);
        play = true;
    }

    void OnCollisionExit2D(Collision2D other) {
         hover.SetActive(false);
         play = false;
    }
}
