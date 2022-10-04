using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "CuriositiesData")]
public class CuriositiesScriptableObject : ScriptableObject
{
    public string CuriosityName;
    [Multiline]
    public string CuriosityDescription;
    public Sprite CuriosityImage;
}