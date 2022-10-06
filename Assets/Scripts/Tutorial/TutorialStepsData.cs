using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TutorialSteps")]
public class TutorialStepsData : ScriptableObject
{
    public string questName;

    [Multiline]
    public string questDescription;
    public Vector3 questIndicatorPosition;
    public Vector3 questIndicatorScale = Vector3.one;
    public bool hiddenIndicator = false;

    public bool showInfoBox = false;
    public bool disableButton = false;
    public Vector3 questInfoPanelPosition;
}
