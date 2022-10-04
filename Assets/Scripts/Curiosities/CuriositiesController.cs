using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuriositiesController : Singleton<CuriositiesController>
{
    [SerializeField]
    private List<CuriositiesScriptableObject> curiosities = new List<CuriositiesScriptableObject>();

    public CuriositiesScriptableObject GetCuriosities()
    {
        return curiosities[Random.Range(0, curiosities.Count)];
    }
}
