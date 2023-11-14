using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Popcorn : MonoBehaviour
{

    [Header("Sprite")]

    public Sprite uncookedPopcorn;
    public Sprite cookedPopcorn;
    public Sprite burntPopcorn;
    //public SpriteRenderer sr;
    private Image popImage;

    [Header("Cooking Time")]

    public float timeToCook;
    private float timeCooked;

    public float timeToBurn;

    private float timeDone;

    private float timeBurnt;
    public float timeToExplode;


    [Header("Other Scripts")]
    public GameObject tempBar;
    private Temperature tempScript;

    public GameObject strikesChecks;
    private Strikes strikeScript;

    [Header("State of Popcorn")]
    private bool isDone;
    private bool isBurnt;
    

    void Start()
    {
        //sr.sprite = uncookedPopcorn;
        popImage = GetComponent<Image>();

        popImage.sprite = uncookedPopcorn;


        timeCooked = Random.Range(0f, 5f);
        timeDone = 0;
        timeBurnt = 0;

        isDone = false;
        isBurnt = false;

        tempScript = tempBar.GetComponent<Temperature>();

        strikeScript = strikesChecks.GetComponent<Strikes>();

    }

    // Update is called once per frame
    void Update()
    {
        timeCooked += Time.deltaTime;

        TimeManagement();

        if (tempScript.Burnt == true)
        {
            isBurnt = true;
            popImage.sprite = burntPopcorn;
        }
    }


    void TimeManagement()
    {
        if (timeCooked >= timeToCook)
        {
            //sr.sprite = cookedPopcorn;
            popImage.sprite = cookedPopcorn;
            isDone = true;
        }

        if (isDone == true && isBurnt == false)
        {
            timeDone += Time.deltaTime;

            if (timeDone >= timeToBurn)
            {
                popImage.sprite = burntPopcorn;
                isBurnt = true;
                isDone = false;
            }
        }

        if (isBurnt == true)
        {
            timeBurnt += Time.deltaTime;

            if (timeBurnt >= timeToExplode)
            {
                SceneManager.LoadScene("Game Over");
            }
        }

        
    }

    public void ResetBucket()
    {
        if (isBurnt == false && isDone == false)
        {
            strikeScript.strikes++;
        }
        else if (isBurnt == true)
        {
            strikeScript.strikes++;
        }

        timeCooked = Random.Range(0f, 5f);
        timeDone = 0;
        timeBurnt = 0;

        isDone = false;
        isBurnt = false;

        popImage.sprite = uncookedPopcorn;

        tempScript.Burnt = false;
        //tempScript.temperature = Random.Range(75f, 125f);
        tempScript.InRed = false;

        
    }
}
