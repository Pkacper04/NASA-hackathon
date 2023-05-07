using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Events;
using Histhack.Core.SaveLoadSystem;

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
        SaveSystem.Save<int>(DayCounter, "CurrentDay",SaveDirectories.Level);
    }

    private void LoadData()
    {
        if (SaveSystem.CheckIfFileExists("CurrentDay",SaveDirectories.Level))
        {
            DayCounter = SaveSystem.Load<int>("CurrentDay",0, SaveDirectories.Level);
        }
    }

    void Start()
    {
        timer = DayLength;
        DayCounterText.text = Language.Instance.GetTranslation(daysKeys) + DayCounter.ToString();
    }
    void Update()
    {
        if (TutorialController.Instance.TutorialGoing || MinigameController.Instance.GameStarted)
            return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            DayCounter++;
            timer = DayLength;
            DayCounterText.text = Language.Instance.GetTranslation(daysKeys) + DayCounter.ToString();
            DataManager.Instance.SaveGame();
        }
    }
}
