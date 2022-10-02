using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Events;
using Game.SaveLoadSystem;

public class DayCounterScript : MonoBehaviour
{
    [SerializeField]
    private float DayLength = 10f;

    private float timer;
    public TMP_Text DayCounterText;
    public int DayCounter;

    private void OnEnable()
    {
        PlayerEvents.Instance.OnSaveGame += SaveData;
        PlayerEvents.Instance.OnLoadGame += LoadData;
    }

    private void OnDisable()
    {
        if (PlayerEvents.Instance != null)
        {                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
            PlayerEvents.Instance.OnSaveGame -= SaveData;
            PlayerEvents.Instance.OnLoadGame -= LoadData;
        }
    }

    private void SaveData()
    {
        Debug.Log("saveDay");
        SaveSystem.SaveInt(DayCounter, "CurrentDay");
    }

    private void LoadData()
    {
        Debug.Log("loadDay");
        if (SaveSystem.CheckIfFileExists("CurrentDay"))
        {
            DayCounter = SaveSystem.LoadInt("CurrentDay");
        }
    }

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
