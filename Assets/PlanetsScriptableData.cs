using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetsData")]
public class PlanetsScriptableData : ScriptableObject
{
    public string PlanetName;
    public string PlanetDescription;
    public int PlanetCashValue;
    public int PlanetResearchPointValue;
}
