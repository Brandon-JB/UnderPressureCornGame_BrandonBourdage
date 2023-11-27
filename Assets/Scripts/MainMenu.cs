using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour
{
    public GameObject buttons;
    public GameObject Credits;
    public GameObject Instructions;
    public GameObject title;
    public GameObject backButton;

    // Start is called before the first frame update
    void Start()
    {
        buttons.SetActive(true);
        title.SetActive(true);
        Credits.SetActive(false);
        Instructions.SetActive(false);
        backButton.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Level");
    }

    public void Instruct()
    {
        Instructions.SetActive(true);
        buttons.SetActive(false);
        backButton.SetActive(true);
    }

    public void Credit()
    {
        Credits.SetActive(true);
        buttons.SetActive(false);
        backButton.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back()
    {
        Credits.SetActive(false);
        Instructions.SetActive(false);
        buttons.SetActive(true);
        backButton.SetActive(false);
    }
}
