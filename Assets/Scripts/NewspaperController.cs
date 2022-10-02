using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class NewspaperController : Singleton<NewspaperController>
{
    [SerializeField]
    private RectTransform newspaperObject;

    [SerializeField]
    private CanvasGroup newspaperGroup;

    [SerializeField]
    private TMP_Text newspaperMessage;

    [SerializeField]
    private TMP_Text newspaperEarnings;

    [SerializeField, Multiline]
    private string startOfNewspaper;

    [SerializeField, Multiline]
    private string EarningsMessage;

    [SerializeField]
    private float animationSpeed;

    [SerializeField]
    private Vector3 startPosition;

    [SerializeField]
    private Vector3 endPosition;

    private int calculatedCash = 0;

    private int calculatedRP = 0;

    private float timeElapsed;

    public void InitNewspaper(List<PlanetsScriptableData> starsFound)
    {
        EnableNewspaper();
        newspaperMessage.text = startOfNewspaper;

        calculatedCash = 0;

        calculatedRP = 0;

        foreach (PlanetsScriptableData data in starsFound)
        {
            switch(data.rarity)
            {
                case Rarity.common:
                    calculatedCash += 200;
                    calculatedRP += 20;
                    break;
                case Rarity.uncommon:
                    calculatedCash += 600;
                    calculatedRP += 60;
                    break;
                case Rarity.rare:
                    calculatedCash += 1000;
                    calculatedRP += 100;
                    break;
            }

            newspaperMessage.text += data.PlanetName + " , ";
        }

        MoneyController.Instance.AddCash(calculatedCash);
        MoneyController.Instance.AddRP(calculatedRP);
        newspaperMessage.text.Remove(newspaperMessage.text.Length - 2, 2);
        newspaperEarnings.text = EarningsMessage + "Cash: " + calculatedCash + " Resource Points: " + calculatedRP;


        timeElapsed = 0;
        StartCoroutine(StartAnimation());
    }

    private IEnumerator StartAnimation()
    {
        while (timeElapsed < animationSpeed)
        {
            newspaperObject.anchoredPosition3D = Vector3.Lerp(startPosition, endPosition, timeElapsed / animationSpeed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
    }

    public void ExitNewspaper()
    {
        Debug.Log("vading out");
        ScreenTransition.Instance.startFadingIn();
        StartCoroutine(waitForScript());
    }

    private IEnumerator waitForScript()
    {
        yield return new WaitUntil(() => ScreenTransition.Instance.InTransition == false);
        DisableNewspaper();
        ScreenTransition.Instance.startFadingOut();
        yield return new WaitUntil(() => ScreenTransition.Instance.InTransition == false);
        MinigameController.Instance.StartCooldown();
    }

    public void DisableNewspaper()
    {
        newspaperGroup.alpha = 0;
        newspaperGroup.blocksRaycasts = false;
        newspaperGroup.interactable = false;
        newspaperObject.anchoredPosition3D = startPosition;
    }

    public void EnableNewspaper()
    {
        newspaperObject.anchoredPosition3D = startPosition;
        newspaperGroup.alpha = 1;
        newspaperGroup.blocksRaycasts = true;
        newspaperGroup.interactable = true;
    }
}
