using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMinigame : buildingFunctionality
{

    [SerializeField]
    private TranslateKeys functionButtonText;


    private void OnEnable()
    {
        MinigameController.Instance.OnEndCooldown += OnEndCooldown;
    }

    private void OnDisable()
    {
        if(MinigameController.Instance != null)
            MinigameController.Instance.OnEndCooldown -= OnEndCooldown;
    }


    private void OnEndCooldown()
    {
        if (currentUI == null)
            return;

        if(currentUI.enabled == true)
        {
            currentUI.FunctionButton.interactable = true;
            currentUI.FunctionButton.onClick.RemoveAllListeners();
            currentUI.FunctionButton.onClick.AddListener(() => StartMinigame());
        }
    }

    public override void DisplayBuilding()
    {
        base.DisplayBuilding();
        currentUI.FunctionButtonText.text = Language.Instance.GetTranslation(functionButtonText);
        currentUI.SellButton.gameObject.SetActive(false);

        if (MinigameController.Instance.HasCooldown)
        {
            currentUI.FunctionButton.interactable = false;
            return;
        }

        currentUI.FunctionButton.interactable = true;
        currentUI.FunctionButton.onClick.RemoveAllListeners();
        currentUI.FunctionButton.onClick.AddListener(() => StartMinigame());


    }

    private void StartMinigame()
    {
        MinigameController.Instance.InitGame();
    }


}
