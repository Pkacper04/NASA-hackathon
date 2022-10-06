using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenTransition : Singleton<ScreenTransition>
{

    [SerializeField]
    private float FadeTime;

    [SerializeField]
    private Image imageToFade;

    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private GraphicRaycaster canvasRaycaster;

    float startValue = 1;

    float endValue = 0;

    float valueInBeetween;

    float timeElapsed;

    bool inTransition = false;

    public bool InTransition { get => inTransition; }
    public void startFadingIn()
    {
        inTransition = true;

        if(!canvasRaycaster.enabled)
            canvasRaycaster.enabled = true;

        imageToFade.color = new Color(0, 0, 0, 0);

        timeElapsed = 0;
        StartCoroutine(FadeIn());
    }

    public void startFadingOut()
    {
        imageToFade.color = new Color(0, 0, 0, 1);
        inTransition = true;
        timeElapsed = 0;
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeIn()
    {
        if (!canvasRaycaster.enabled)
            canvasRaycaster.enabled = true;

        while (timeElapsed < FadeTime)
        {
            valueInBeetween = Mathf.Lerp(endValue, startValue, timeElapsed / FadeTime);
            imageToFade.color = new Color(0, 0, 0, valueInBeetween);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        inTransition = false;
    }

    private IEnumerator FadeOut()
    {
        while (timeElapsed < FadeTime)
        {
            valueInBeetween = Mathf.Lerp(startValue, endValue, timeElapsed / FadeTime);
            imageToFade.color = new Color(0, 0, 0, valueInBeetween);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        if (canvasRaycaster.enabled)
            canvasRaycaster.enabled = false;

        inTransition = false;
    }
}
