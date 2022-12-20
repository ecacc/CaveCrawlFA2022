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
    public string videoName;

    void Start()
    {
        Audio.beginning = false;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoName);
    }

    // Update is called once per frame
    void Update()
    {
        if((videoPlayer.frame > 0) && (videoPlayer.isPlaying == false) && playVid) {
            video.SetActive(false);
            Skip();
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
        if(videoName == "CaveCrawlIntro.mp4") {
            SceneManager.LoadSceneAsync("Level1");
        } else {
            SceneManager.LoadSceneAsync("StartPage");
        }
    }
}
