using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResearchCenterBuilding : buildingFunctionality
{

    [SerializeField]
    private string functionButtonText;

    public override void DisplayBuilding()
    {
        base.DisplayBuilding();
        currentUI.FunctionButtonText.text = functionButtonText;
        currentUI.FunctionButton.interactable = true;
        currentUI.FunctionButton.onClick.RemoveAllListeners();
        currentUI.FunctionButton.onClick.AddListener(() => OpenResources());

    }

    private void OpenResources()
    {
        TechTreeController.Instance.EnableTechTreeUI();
    }


}
