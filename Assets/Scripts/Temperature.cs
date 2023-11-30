using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Temperature : MonoBehaviour
{
    public float temperature;
    private float maxTemperature = 200;
    private Image tempBar;

    public float TimeToBurn;
    public float TimeInRed;

    public bool InRed;
    public bool Burnt;
    public GameObject DangerTriangle;

    public bool favorUp;
    // Start is called before the first frame update
    void Start()
    {
        Burnt = false;
        InRed = false;
        TimeInRed = 0;
        temperature = Random.Range(75f, 125f);
        tempBar = GetComponent<Image>();

        RerollFavor();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            if (favorUp == true)
            {
                if (temperature > 0 && temperature < maxTemperature)
                {
                    temperature *= Random.Range(0.99f, 1.011f);
                }
                else if (temperature <= 0)
                {
                    temperature += Random.Range(0f, 10f);
                }
                else if (temperature >= maxTemperature)
                {
                    temperature -= Random.Range(0f, 10f);
                }
            }
            else if (favorUp == false)
            {
                if (temperature > 0 && temperature < maxTemperature)
                {
                    temperature *= Random.Range(0.989f, 1.01f);
                }
                else if (temperature <= 0)
                {
                    temperature += Random.Range(0f, 10f);
                }
                else if (temperature >= maxTemperature)
                {
                    temperature -= Random.Range(0f, 10f);
                }
            }
        }

        tempBar.fillAmount = temperature / maxTemperature;

        CheckBar();
    }

    void CheckBar()
    {
        if (temperature / maxTemperature <= 0.25f || temperature / maxTemperature >= 0.75f)
        {
            InRed = true;
        }
        else
        {
            InRed = false;
        }

        if (InRed == true)
        {
            DangerTriangle.SetActive(true);
            TimeInRed += Time.deltaTime;

            if (TimeInRed >= TimeToBurn)
            {
                Burnt = true;
            }
        }
        else if(InRed == false)
        {
            TimeInRed = 0;
            DangerTriangle.SetActive(false);
        }

    }

    public void PlusSign()
    {
        temperature *= 1.6f;
    }

    public void MinusSign()
    {
        temperature *= 0.65f;
    }

    public void RerollFavor()
    {
        if (Random.Range(-1f, 1f) >= 0)
        {
            favorUp = true;
        }
        else if (Random.Range(-1f, 1f) < 0)
        {
            favorUp = false;
        }
    }
}
