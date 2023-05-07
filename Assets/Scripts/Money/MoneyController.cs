using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Events;
using Histhack.Core.SaveLoadSystem;

public class MoneyController : Singleton<MoneyController>
{
    [SerializeField] public int totalCash = 0;
    [SerializeField] public int totalResearchPoints = 0;

    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text researchPointsText;



    private void OnEnable()
    {
        PlayerEvents.Instance.OnSaveGame += SaveStats;
        PlayerEvents.Instance.OnLoadGame += LoadGame;
    }

    private void OnDisable()
    {
        if (PlayerEvents.Instance != null)
        {
            PlayerEvents.Instance.OnSaveGame -= SaveStats;
            PlayerEvents.Instance.OnLoadGame -= LoadGame;
        }
    }


    private void SaveStats()
    {
        SaveSystem.Save<int>(totalCash, "CashStorage", SaveDirectories.Player);
        SaveSystem.Save<int>(totalResearchPoints, "RPStorage", SaveDirectories.Player);
    }

    private void LoadGame()
    {
        if(SaveSystem.CheckIfFileExists("CashStorage",SaveDirectories.Player))
        {
            totalCash = SaveSystem.Load<int>("CashStorage",0,SaveDirectories.Player);
        }

        if(SaveSystem.CheckIfFileExists("RPStorage",SaveDirectories.Player))
        {
            totalResearchPoints = SaveSystem.Load<int>("RPStorage",0,SaveDirectories.Player);
        }
    }

    private void Start()
    {
        moneyText.text = totalCash.ToString();
        researchPointsText.text = totalResearchPoints.ToString();
    }

    public void AddCash(int cashToAdd)
    {
        totalCash += cashToAdd;
        moneyText.text = totalCash.ToString();
    }

    public void RemoveCash(int cashToRemove)
    {
        totalCash -= cashToRemove;
        moneyText.text = totalCash.ToString();
    }

    public void AddRP(int rp)
    {
        totalResearchPoints += rp;
        researchPointsText.text = totalResearchPoints.ToString();
    }

    public void RemoveRP(int rp)
    {
        totalResearchPoints -= rp;
        researchPointsText.text = totalResearchPoints.ToString();
    }

    public bool CheckIfCanPurchase(int cash)
    {
        return (totalCash >= cash);
    }

    public bool CheckIfCanUpgrade(int rp)
    {
        return (totalResearchPoints >= rp);
    }


}
