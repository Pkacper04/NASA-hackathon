using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
            Debug.Log("End game");
            //EndGame
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

}
