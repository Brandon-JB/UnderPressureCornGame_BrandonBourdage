using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public float timeToWin;
    private float timePassed;


    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1.0f;
        timePassed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }

        timePassed += Time.deltaTime;

        if (timePassed > timeToWin)
        {
            SceneManager.LoadScene("Win Screen");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Main Menu");
    }
}
