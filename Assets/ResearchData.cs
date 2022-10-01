using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ResearchData")]

public class ResearchData : ScriptableObject
{
    public string ResearchName;
    public int ResearchCost;
    public int BuildingCost;
    public string ResearchDescription;
    public bool isPurchased = false;
    public ResearchData previousUpgrade = null;
    public ResearchData nextUpgrade = null;

}
