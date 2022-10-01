using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TechTreeController : Singleton<TechTreeController>
{
    public List<ResearchData> UpgradesList = new List<ResearchData>();

    [SerializeField]
    private ResearchData firstBuilding;

    [SerializeField]
    private TechTreeUI TechTreeUI;

    [SerializeField]
    private string boughtText;

    private void OnDisable()
    {
        foreach (ResearchData data in UpgradesList)
            data.isPurchased = false;

        firstBuilding.isPurchased = true;
    }

    public void EnableTechTreeUI()
    {
        if(TechTreeUI.TechtreeActive())
        {
            DisavleTechTreeUI();
            return;
        }
        TechTreeUI.EnableTechTree();
        
    }

    public void DisavleTechTreeUI()
    {
        TechTreeUI.DisableTechTree();
    }

    public bool isUnlocked(ResearchData Upgrade)
    {
        bool isBought = false;
        for (int i = 0; i < UpgradesList.Count; i++)
        {
            if (Upgrade == UpgradesList[i])
            {
                isBought = UpgradesList[i].isPurchased;
                break;
            }
        }
        return isBought;
    }

    public void BuyUpgrade(UpgradeData upgradeData)
    {
        Debug.Log("before upgrade");
        if (!CanBuyUpgrade(upgradeData.CurrentResearchData))
            return;

        Debug.Log("Upgrade");

        MoneyController.Instance.RemoveRP(upgradeData.CurrentResearchData.ResearchCost);
        upgradeData.CurrentResearchData.isPurchased = true;
        upgradeData.ButtonText.text = boughtText;
        upgradeData.ObjectButton.interactable = false;
    }


    public bool CanBuyUpgrade(ResearchData Upgrade)
    {
        Debug.Log("first check");
        if (MoneyController.Instance.CheckIfCanUpgrade(Upgrade.ResearchCost) == false)
            return false;

        Debug.Log("second check");

        if (!CheckIfCanUpgrade(Upgrade))
            return false;
        Debug.Log("third check");
        return true;
    }

    public bool CheckIfCanUpgrade(ResearchData Upgrade)
    {
        if (Upgrade.previousUpgrade == firstBuilding)
            return true;

        if (Upgrade.previousUpgrade == null)
            return true;
        else if (Upgrade.nextUpgrade == null)
            return false;
        else
        {
            if (Upgrade.previousUpgrade.isPurchased)
                return true;
            return false;
        }
    }
}
