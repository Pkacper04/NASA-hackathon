using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;

public class TutorialsEvents : MonoBehaviour
{

    [SerializeField]
    private List<SocketsTutorialEvents> events = new List<SocketsTutorialEvents>();

    private void OnEnable()
    {
        PlayerEvents.Instance.OnTutorialStepFinish += CheckTutorialOnFinish;
        PlayerEvents.Instance.OnTutorialStepStarted += CheckTutorialOnStart;
    }

    private void OnDisable()
    {
        PlayerEvents.Instance.OnTutorialStepFinish -= CheckTutorialOnFinish;
        PlayerEvents.Instance.OnTutorialStepStarted -= CheckTutorialOnStart;
    }

    private void CheckTutorialOnFinish(TutorialStepsData tutorialStep)
    {
        foreach (SocketsTutorialEvents tutorialEvent in events)
        {
            if (tutorialEvent.invokeType == TutorialEventTypes.OnStart)
                continue;

            if (tutorialEvent.steps == tutorialStep && tutorialEvent.eventToStart != null)
            {
                tutorialEvent.eventToStart.Invoke();
            }
        }
    }

    private void CheckTutorialOnStart(TutorialStepsData tutorialStep)
    {
        foreach (SocketsTutorialEvents tutorialEvent in events)
        {
            if (tutorialEvent.invokeType == TutorialEventTypes.OnFinish)
                continue;

            if (tutorialEvent.steps == tutorialStep && tutorialEvent.eventToStart != null)
            {
                tutorialEvent.eventToStart.Invoke();
            }
        }
    }
}

[System.Serializable]
public class SocketsTutorialEvents
{

    public TutorialEventTypes invokeType;
    public TutorialStepsData steps;
    public UnityEvent eventToStart;
}

public enum TutorialEventTypes
{
    OnStart,
    OnFinish
}