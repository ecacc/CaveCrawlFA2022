using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour  {

        public static bool GameisPaused = false;
        public GameObject pauseMenuUI;
        public GameObject deathMenuUI;
        public GameObject winMenuUI;
    public GameObject P_last_heart;
    public GameObject S_last_heart;
        //public AudioMixer mixer;
        //public static float volumeLevel = 1.0f;
        //private Slider sliderVolumeCtrl;

        void Awake (){
                //SetLevel (volumeLevel);
                //GameObject sliderTemp = GameObject.FindWithTag("PauseMenuSlider");
                // if (sliderTemp != null){
                //         sliderVolumeCtrl = sliderTemp.GetComponent<Slider>();
                //         sliderVolumeCtrl.value = volumeLevel;
                // }
        }

        void Start (){
                pauseMenuUI.SetActive(false);
                deathMenuUI.SetActive(false);
        }

        void Update (){
                if (Input.GetKeyDown(KeyCode.Escape)){
                        if (GameisPaused){
                                Resume();
                        }
                        else{
                                Pause();
                        }
                }
                if (P_last_heart.activeSelf == false)
                {
                    Die();
                }
                if (S_last_heart.activeSelf == false)
                {
                    Win();
                }
        }

        void Die()
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        void Win()
        {
            winMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }

    void Pause(){
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0f;
                GameisPaused = true;
        }

        public void Resume(){
                pauseMenuUI.SetActive(false);
                Time.timeScale = 1f;
                GameisPaused = false;
        }

        public void Restart(){
                Time.timeScale = 1f;
                //restart the game:
                SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
                //SceneManager.LoadScene ("StartPage");
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
