using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTreeController : MonoBehaviour
{
    public List<ResearchData> UpgradesList = new List<ResearchData>();

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

    public void BuyUpgrade(ResearchData Upgrade, MoneyController ResearchPoints)
    {
        ResearchPoints.totalResearchPoints -= Upgrade.ResearchCost;
        Upgrade.isPurchased = true;
    }


}
