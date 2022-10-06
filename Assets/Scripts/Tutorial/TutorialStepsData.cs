using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TutorialSteps")]
public class TutorialStepsData : ScriptableObject
{
    public string questName;
    public string questDescription;
    public Vector3 questIndicatorPosition;
    public Vector3 questIndicatorScale = Vector3.one;
    public bool hiddenIndicator = false;
}
