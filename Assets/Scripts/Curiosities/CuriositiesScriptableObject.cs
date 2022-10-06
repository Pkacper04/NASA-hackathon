using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "CuriositiesData")]
public class CuriositiesScriptableObject : ScriptableObject
{
    public TranslateKeys CuriosityName;
    public TranslateKeys CuriosityDescription;

    public Sprite CuriosityImage;
}