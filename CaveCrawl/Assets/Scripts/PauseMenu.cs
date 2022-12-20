using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour  {

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public GameObject resumeUI;
        //public AudioMixer mixer;
        //public static float volumeLevel = 1.0f;
        //private Slider sliderVolumeCtrl;

        void Awake () {
                //SetLevel (volumeLevel);
                //GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                // if (sliderTemp != null){
                //         sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                //         sliderVolumeCtrl.value = volumeLevel;
                // }
        }

        void Start () {
             GameisPaused = false;
             pauseMenuUI.SetActive(false);
             resumeUI.SetActive(false);
             
        }

        void Update () {
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused) {
                                Resume();
                        }
                        else {
                                Pause();
                        }
                }
        }

        void Pause() {
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                Debug.Log(Time.timeScale);
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                resumeUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void Restart(){
                Time.timeScale = 1f;
                PlayerHealth.health = 1f;
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
        }

      public void QuitGame() {
                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
                #else
                Application.Quit();
                #endif
      }

        // public void SetLevel (float sliderValue){
        //         mixer.SetFloat("MusicVolume", Mathf.Log10 (sliderValue) * 20);
        //         volumeLevel = sliderValue;
        // }
}
