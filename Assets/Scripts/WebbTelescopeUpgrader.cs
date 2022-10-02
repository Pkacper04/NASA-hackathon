using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WebbTelescopeUpgrader : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Sprite model1;

    [SerializeField]
    private Sprite model2;

    [SerializeField]
    private Sprite model3;

    [SerializeField]
    private List<ResearchData> necessaryResearch = new List<ResearchData>();

    [SerializeField, Scene]
    private string SceneToChange;

    private void OnEnable()
    {
        TechTreeController.Instance.OnResearchBuy += OnReasearchPurchase;
    }

    private void OnDisable()
    {
        if(TechTreeController.Instance != null)
            TechTreeController.Instance.OnResearchBuy -= OnReasearchPurchase;
    }

    private void OnReasearchPurchase()
    {
        int unlockedTechnologies = 0;

        for(int i=0;i<necessaryResearch.Count;i++)
        {
            if(TechTreeController.Instance.isUnlocked(necessaryResearch[i]))
                unlockedTechnologies++;
        }

        if (unlockedTechnologies == necessaryResearch.Count)
        {
            ScreenTransition.Instance.startFadingIn();
            StartCoroutine(WaitForFade());
            return;
        }

        float value = (float)unlockedTechnologies / (float)necessaryResearch.Count; 


        if(value > .4f && value < .8f)
        {
            spriteRenderer.sprite = model2;
        }
        else if(value > .8f)
        {
            spriteRenderer.sprite = model3;
        }


    }

    public IEnumerator WaitForFade()
    {
        yield return new WaitUntil(() => ScreenTransition.Instance.InTransition == false);
        SceneManager.LoadScene(SceneToChange);
    }
}
