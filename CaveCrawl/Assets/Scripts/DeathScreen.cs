using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DeathScreen : MonoBehaviour  {

    public GameObject P_last_heart;
    public static int currlevel;
    public int level;

    void Start () {
        currlevel = level;
        P_last_heart.SetActive(true);
    }

    void Update (){
        if (P_last_heart.activeSelf == false) {
            Die();
        }
    }

    void Die() {
        currlevel = level;
        SceneManager.LoadScene("DeathPage");
    }
}

