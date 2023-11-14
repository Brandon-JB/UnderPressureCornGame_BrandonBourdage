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
    private float TimeInRed;

    public bool InRed;
    public bool Burnt;
    public GameObject DangerTriangle;
    // Start is called before the first frame update
    void Start()
    {
        Burnt = false;
        InRed = false;
        TimeInRed = 0;
        temperature = 100;
        tempBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (temperature > 0 && temperature < maxTemperature)
        {
            temperature += Random.Range(-1f, 1f);
        }
        else if (temperature <= 0)
        {
            temperature += Random.Range(0f, 1f);
        }
        else if (temperature >= maxTemperature)
        {
            temperature -= Random.Range(0f, 1f);
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
        temperature += 20f;
    }

    public void MinusSign()
    {
        temperature -= 20f;
    }
}