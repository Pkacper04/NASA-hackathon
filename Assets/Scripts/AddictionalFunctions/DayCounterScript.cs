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

    [SerializeField]
    private TranslateKeys daysKeys;

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
        SaveSystem.SaveInt(DayCounter, "CurrentDay");
    }

    private void LoadData()
    {
        if (SaveSystem.CheckIfFileExists("CurrentDay"))
        {
            DayCounter = SaveSystem.LoadInt("CurrentDay");
        }
    }

    void Start()
    {
        timer = DayLength;
        DayCounterText.text = Language.Instance.GetTranslation(daysKeys) + DayCounter.ToString();
    }
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            DayCounter++;
            timer = DayLength;
            DayCounterText.text = Language.Instance.GetTranslation(daysKeys) + DayCounter.ToString();
        }
    }
}
