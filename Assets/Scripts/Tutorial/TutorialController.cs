using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : Singleton<TutorialController>
{
    [SerializeField]
    private CanvasGroup startingTutorial;

    [SerializeField]
    private CanvasGroup endTutorialPanel;

    [SerializeField]
    private List<TutorialStepsData> steps = new List<TutorialStepsData>();

    [SerializeField]
    private RectTransform indicator;

    [SerializeField]
    private RectTransform indicatorParent;

    private bool tutorialGoing = true;

    public bool TutorialGoing { get => tutorialGoing; set => tutorialGoing = value; }

    int currentQuest = -1;

    private RectTransform lastObject = null;

    // Start is called before the first frame update
    void Start()
    {
        ScreenTransition.Instance.startFadingOut();
        hideFinalTutorialPanel();
        startTutorial();
    }

    private void startTutorial()
    {
        startingTutorial.alpha = 1.0f;
        startingTutorial.interactable = true;
        startingTutorial.blocksRaycasts = true;
    }

    public void DisplayFinalTutorialPanel()
    {
        tutorialGoing = false;
        endTutorialPanel.alpha = 1;
        endTutorialPanel.interactable = true;
        endTutorialPanel.blocksRaycasts = true;
    }

    public void hideTutorialPanel()
    {
        startingTutorial.alpha = 0f;
        startingTutorial.interactable = false;
        startingTutorial.blocksRaycasts = false;
        NextQuest();
    }

    public void hideFinalTutorialPanel()
    {
        endTutorialPanel.alpha = 0;
        endTutorialPanel.interactable = false;
        endTutorialPanel.blocksRaycasts = false;
    }

    private void NextQuest()
    {
        currentQuest++;
        if (lastObject != null)
            DeleteLastObject();

        if (currentQuest == steps.Count)
        {
            DisplayFinalTutorialPanel();
            return;
        }

        if (steps[currentQuest].hiddenIndicator)
            return;

        lastObject = Instantiate(indicator, steps[currentQuest].questIndicatorPosition, Quaternion.identity,indicatorParent);
        lastObject.anchoredPosition3D = steps[currentQuest].questIndicatorPosition;
        lastObject.localScale = steps[currentQuest].questIndicatorScale;
    }

    public void DeleteLastObject()
    {
        Destroy(lastObject.gameObject);
        lastObject = null;
    }

    public void FinishQuest(TutorialStepsData currentQuest)
    {
        if (currentQuest != steps[this.currentQuest])
            return;

        NextQuest();
    }
}
