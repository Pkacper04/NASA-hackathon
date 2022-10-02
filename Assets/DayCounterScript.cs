using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DayCounterScript : MonoBehaviour
{
    [SerializeField]
    private float DayLength = 10f;

    private float timer;
    public TMP_Text DayCounterText;
    public int DayCounter;

    void Start()
    {
        timer = DayLength;
        DayCounterText.text = "Day: " + DayCounter.ToString();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            DayCounter++;
            timer = DayLength;
            DayCounterText.text = "Day: " + DayCounter.ToString();
        }
    }
}
