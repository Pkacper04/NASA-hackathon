using Events;
using Game.SaveLoadSystem;
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
    private ResearchData rocketBuilding;

    [SerializeField]
    private TechTreeUI TechTreeUI;

    [SerializeField]
    private TranslateKeys boughtText;

    [SerializeField]
    private TutorialStepsData techTreeUIQuest;

    [SerializeField]
    private TutorialStepsData rocketBuyQuest;

    private bool blockTechTree = false;

    public bool BlockTechTree { get => blockTechTree; set => blockTechTree = value; }


    private bool canFinishQuestRocket = false;

    public Action OnResearchBuy;

    public void CallOnResearchBuy()
    {
        if (OnResearchBuy != null)
            OnResearchBuy.Invoke();
    }

    public Action<UpgradeData> OnSpecificResearchBuy;


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

        foreach (ResearchData data in UpgradesList)
            data.isPurchased = false;

        firstBuilding.isPurchased = true;
    }

    private void SaveData()
    {
        List<bool> upgradesList = new List<bool>();
        foreach(ResearchData data in UpgradesList)
        {
            upgradesList.Add(data.isPurchased);
        }
        SaveSystem.SaveBoolList(upgradesList, "UpgradeLists");
    }

    private void LoadData()
    {
        if(SaveSystem.CheckIfFileExists("UpgradeLists"))
        {
            List<bool> upgradesList = new List<bool>(SaveSystem.LoadBoolList("UpgradeLists"));
            List<UpgradeData> upgradeData = new List<UpgradeData>(FindObjectsOfType<UpgradeData>());


            for(int i=0;i<upgradesList.Count; i++)
            {
                UpgradesList[i].isPurchased = upgradesList[i];
            }

            for(int i=0; i< UpgradesList.Count; i++)
            {
                for(int j=0; j<upgradeData.Count;j++)
                {
                    if (upgradeData[j].CurrentResearchData == UpgradesList[i] && UpgradesList[i].isPurchased)
                    {
                        CallOnSpecificReasearchBuy(upgradeData[j]);
                        upgradeData[j].ButtonText.text = Language.Instance.GetTranslation(boughtText);
                        upgradeData[j].ObjectButton.interactable = false;
                        break;
                    }
                }
            }
        }
    }


    public void CallOnSpecificReasearchBuy(UpgradeData data)
    {
        if (OnSpecificResearchBuy != null)
            OnSpecificResearchBuy.Invoke(data);
    }


    public void EnableTechTreeUI()
    {
        if (blockTechTree)
            return;

        if(TutorialController.Instance.TutorialGoing)
        {
            TutorialController.Instance.FinishQuest(techTreeUIQuest);
        }

        ClosePopups.Instance.CloseWithoutOne(this);
        if(TechTreeUI.TechtreeActive())
        {
            DisavleTechTreeUI();
            return;
        }
        TechTreeUI.EnableTechTree();
        
    }

    public void DisavleTechTreeUI()
    {
        if(TutorialController.Instance.TutorialGoing)
        {
            if (canFinishQuestRocket)
            {
                TutorialController.Instance.FinishQuest(rocketBuyQuest);
                blockTechTree = true;
            }
        }
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
        if (!CanBuyUpgrade(upgradeData.CurrentResearchData))
            return;

        if(upgradeData.CurrentResearchData == rocketBuilding)
        {
            canFinishQuestRocket = true;
        }
        MoneyController.Instance.RemoveRP(upgradeData.CurrentResearchData.ResearchCost);
        upgradeData.CurrentResearchData.isPurchased = true;
        upgradeData.ButtonText.text = Language.Instance.GetTranslation(boughtText);
        upgradeData.ObjectButton.interactable = false;
        CallOnResearchBuy();
        CallOnSpecificReasearchBuy(upgradeData);
    }


    public bool CanBuyUpgrade(ResearchData Upgrade)
    {
        if (MoneyController.Instance.CheckIfCanUpgrade(Upgrade.ResearchCost) == false)
            return false;


        if (!CheckIfCanUpgrade(Upgrade))
            return false;

        return true;
    }

    public bool CheckIfCanUpgrade(ResearchData Upgrade)
    {
        if (Upgrade.previousUpgrade == firstBuilding)
            return true;

        if (Upgrade.previousUpgrade == null)
            return true;
        else
        {
            if (Upgrade.previousUpgrade.isPurchased)
                return true;
            return false;
        }
    }
}
