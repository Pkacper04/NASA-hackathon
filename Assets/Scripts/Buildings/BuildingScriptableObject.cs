using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Buildings/BuildingData")]
public class BuildingScriptableObject : ScriptableObject
{
    public Sprite BuildingSprite;
    public string Header;

    [Multiline]
    public string Description;

    public int Price;

    [HorizontalLine]

    public GameObject BuildingPrefab;

}
