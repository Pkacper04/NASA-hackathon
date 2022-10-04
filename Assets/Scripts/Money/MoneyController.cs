using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Events;
using Game.SaveLoadSystem;

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
        SaveSystem.SaveInt(totalCash, "CashStorage");
        SaveSystem.SaveInt(totalResearchPoints, "RPStorage");
    }

    private void LoadGame()
    {
        if(SaveSystem.CheckIfFileExists("CashStorage"))
        {
            totalCash = SaveSystem.LoadInt("CashStorage");
        }

        if(SaveSystem.CheckIfFileExists("RPStorage"))
        {
            totalResearchPoints = SaveSystem.LoadInt("RPStorage");
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
