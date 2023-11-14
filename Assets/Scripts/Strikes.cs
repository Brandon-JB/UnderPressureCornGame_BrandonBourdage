using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Strikes : MonoBehaviour
{
    public int strikes;

    public GameObject strike1;
    public GameObject strike2;

    private void Start()
    {
        strikes = 0;
    }

    void Update()
    {
        if (strikes == 0)
        {
            strike1.SetActive(false);
            strike2.SetActive(false);
        }
        else if (strikes == 1)
        {
            strike1.SetActive(true);
            strike2.SetActive(false);
        }
        else if (strikes == 2)
        {
            strike1.SetActive(true);
            strike2.SetActive(true);
        }
        else if (strikes == 3)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
}
