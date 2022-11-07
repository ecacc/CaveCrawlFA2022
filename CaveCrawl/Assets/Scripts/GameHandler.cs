using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    public int level = 1;

    public int lives = 3;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        this.lives = 3;
    }

    private void LoadLevel(int level)
    {
        this.level = level;
        //SceneManager.LoadScene();
    }
}
