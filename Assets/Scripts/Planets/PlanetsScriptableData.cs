using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetsData")]
public class PlanetsScriptableData : ScriptableObject
{
    public Sprite planetSprite;
    public TranslateKeys PlanetName;
    public TranslateKeys PlanetDescription;
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