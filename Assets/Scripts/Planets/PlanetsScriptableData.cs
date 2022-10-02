using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetsData")]
public class PlanetsScriptableData : ScriptableObject
{
    public Sprite planetSprite;
    public string PlanetName;
    public string PlanetDescription;
    public int PlanetCashValue;
    public int PlanetResearchPointValue;
    public Rarity rarity;
}

public enum Rarity
{
    common,
    uncommon,
    rare
}