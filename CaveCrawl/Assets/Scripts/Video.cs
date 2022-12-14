using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public GameObject video;
    private bool playVid;

    // Update is called once per frame
    void Update()
    {
        if((videoPlayer.frame > 0) && (videoPlayer.isPlaying == false) && playVid) {
            video.SetActive(false);
            SceneManager.LoadSceneAsync("Level1");
        }
        if(PauseMenu.GameisPaused) {
            playVid = false;
            videoPlayer.Pause();
        } else {
            videoPlayer.Play();
            playVid = true;
        }
    }

    public void Skip() {
        SceneManager.LoadSceneAsync("Level1");
    }
}
