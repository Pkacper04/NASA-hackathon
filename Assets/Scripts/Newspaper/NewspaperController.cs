using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

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

    [SerializeField]
    private TranslateKeys startOfNewspaper;

    [SerializeField]
    private TranslateKeys EarningsMessage;

    [SerializeField]
    private TranslateKeys cashKey;

    [SerializeField]
    private TranslateKeys RpKey;

    [SerializeField]
    private Image starImage;

    [SerializeField]
    private TMP_Text starName;

    [SerializeField]
    private TMP_Text starDescription;

    [SerializeField]
    private float animationSpeed;

    [SerializeField]
    private Vector3 startPosition;

    [SerializeField]
    private Vector3 endPosition;

    [SerializeField]
    private AudioSource backgroundMusic;

    private int calculatedCash = 0;

    private int calculatedRP = 0;

    private float timeElapsed;

    public void InitNewspaper(List<PlanetsScriptableData> starsFound)
    {
        EnableNewspaper();
        newspaperMessage.text = Language.Instance.GetTranslation(startOfNewspaper)+": ";

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

            newspaperMessage.text += Language.Instance.GetTranslation(data.PlanetName) + " , ";
        }

        MoneyController.Instance.AddCash(calculatedCash);
        MoneyController.Instance.AddRP(calculatedRP);
        newspaperMessage.text.Remove(newspaperMessage.text.Length - 2, 2);
        newspaperEarnings.text = Language.Instance.GetTranslation(EarningsMessage) + "\n" + Language.Instance.GetTranslation(cashKey)+": " + calculatedCash + "\n" + Language.Instance.GetTranslation(RpKey) + ": " + calculatedRP;

        PlanetsScriptableData randomStar = starsFound[UnityEngine.Random.Range(0, starsFound.Count)];

        starImage.sprite = randomStar.planetSprite;
        starName.text = Language.Instance.GetTranslation(randomStar.PlanetName);
        starDescription.text = Language.Instance.GetTranslation(randomStar.PlanetDescription);


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
        ScreenTransition.Instance.startFadingIn();
        backgroundMusic.Play();
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
