using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsController : MonoBehaviour
{
    [SerializeField]
    private List<PlanetsScriptableData> commonPlanets = new List<PlanetsScriptableData>();

    [SerializeField]
    private List<PlanetsScriptableData> uncommonPlanets = new List<PlanetsScriptableData>();

    [SerializeField]
    private List<PlanetsScriptableData> rarePlanets = new List<PlanetsScriptableData>();
    
    
    public PlanetsScriptableData GetCommonPlanet()
     {
       return commonPlanets[Random.Range(0, commonPlanets.Count)];
     }
    public PlanetsScriptableData GetUncommonPlanet()
    {
        return uncommonPlanets[Random.Range(0, uncommonPlanets.Count)];
    }
    public PlanetsScriptableData GetRarePlanet()
    {
        return rarePlanets[Random.Range(0, rarePlanets.Count)];
    }
}

