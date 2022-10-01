using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservatoryUsage : buildingFunctionality
{
    [SerializeField]
    private int amountToGive;

    [SerializeField]
    private float timeToGive;

    [SerializeField]
    private int buildingLevel = 1;

    [SerializeField]
    private string functionButtonText;

    [SerializeField]
    private ResearchData Level1;

    [SerializeField]
    private ResearchData Level2;

    [SerializeField]
    private ResearchData Level3;

    [SerializeField]
    private bool HasUpgrades = false;

    private ResearchData currentLevel;


    private float time = 0;

    public int AmountToGive { get => amountToGive; set => amountToGive = value; }


    private void Start()
    {
        base.Start();
        time = timeToGive;
        currentLevel = Level1;
    }

    public override void DisplayBuilding()
    {
        base.DisplayBuilding();
        currentUI.FunctionButtonText.text = functionButtonText;
        currentUI.FunctionButton.onClick.AddListener(() => UpgradeBuilding());

        if (HasUpgrades)
        {
            currentUI.DeactiveButton();
            if (currentLevel == Level1)
            {
                if (TechTreeController.Instance.CheckIfCanUpgrade(Level2))
                {
                    currentUI.ActivePrice(Level2.BuildingCost);
                    currentUI.ActivateButton();
                }
            }
            else if(currentLevel == Level2)
            {
                if (TechTreeController.Instance.CheckIfCanUpgrade(Level2))
                {
                    currentUI.ActivePrice(Level3.BuildingCost);
                    currentUI.ActivateButton();
                }
            }
        }
    }

    private void UpgradeBuilding()
    {

    }

    private void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = timeToGive;
            Debug.Log("Add RP");
;            //adding amount
        }
    }
}
