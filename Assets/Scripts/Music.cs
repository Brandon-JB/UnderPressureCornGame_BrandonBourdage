using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
    public AudioSource AudioSource;
    static Music Instance;

    private bool playMusic;


    /*void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }*/


    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;

            SceneManager.sceneLoaded += OnSceneLoaded;

            playMusic = true;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            AudioSource.pitch = 0f;
        }

        else if (Time.timeScale == 1f && playMusic == true)
        {
            AudioSource.pitch = 1f;
        }
    }

    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game Over" || scene.name == "Win Screen")
        {
            //Debug.Log(scene.name);
            playMusic = false;
            AudioSource.pitch = 0f;
        }
        else if (scene.name == "Main Menu" || scene.name == "Level")
        {
            //Debug.Log(scene.name);
            playMusic = true;
            AudioSource.pitch = 1f;
        }
    }
    
}
