using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchoolingBuilding : buildingFunctionality
{
    [SerializeField]
    private int amountToGiveCash;

    [SerializeField]
    private int amountToGiveRP;

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

    [SerializeField]
    private Sprite Level2Sprite;

    [SerializeField]
    private Sprite Level3Sprite;

    public int AmountToGiveCash { get => amountToGiveCash; set => amountToGiveCash = value; }

    public int AmountToGiveRP { get => amountToGiveRP; set => amountToGiveRP = value; }

    private List<ObservatoryUsage> Observatories = new List<ObservatoryUsage>();
    private List<RekrutacjaBuilding> Recrutations = new List<RekrutacjaBuilding>();


    private void OnEnable()
    {
        Observatories = new List<ObservatoryUsage>(GameObject.FindObjectsOfType<ObservatoryUsage>());
        Recrutations = new List<RekrutacjaBuilding>(GameObject.FindObjectsOfType<RekrutacjaBuilding>());

        foreach(ObservatoryUsage ob in Observatories)
        {
            ob.AmountToGive += amountToGiveRP;
        }

        foreach(RekrutacjaBuilding rk in Recrutations)
        {
            rk.AmountToGive += amountToGiveCash;
        }
    }

    public int AddBuildingToList(ObservatoryUsage observer)
    {
        if (Observatories.Contains(observer))
            return 0;

        Observatories.Add(observer);

        if(currentLevel == Level1)
        {
            return 1;
        }
        else if(currentLevel == Level2)
        {
            return 3;
        }
        else
        {
            return 5;
        }
    }

    public int AddBuildingToList(RekrutacjaBuilding recrutation)
    {

        if (Recrutations.Contains(recrutation))
            return 0;

        Recrutations.Add(recrutation);

        if (currentLevel == Level1)
        {
            return 5;
        }
        else if (currentLevel == Level2)
        {
            return 10;
        }
        else
        {
            return 20;
        }
    }

    private void Start()
    {
        base.Start();
        currentLevel = Level1;
    }

    public override void ChangeCurrentLevel(int level)
    {
        if (level == 1)
            currentLevel = Level1;
        else if (level == 2)
        {
            currentLevel = Level2;
            foreach (ObservatoryUsage ob in Observatories)
            {
                ob.AmountToGive += 2;
            }

            foreach (RekrutacjaBuilding rk in Recrutations)
            {
                rk.AmountToGive += 5;
            }
            SpriteRendererO.sprite = Level2Sprite;
        }
        else
        {
            currentLevel = Level3;
            foreach (ObservatoryUsage ob in Observatories)
            {
                ob.AmountToGive += 2;
            }

            foreach (RekrutacjaBuilding rk in Recrutations)
            {
                rk.AmountToGive += 10;
            }
            SpriteRendererO.sprite = Level3Sprite;
        }
    }

    public override void DisplayBuilding()
    {
        base.DisplayBuilding();
        currentUI.FunctionButtonText.text = functionButtonText;
        currentUI.FunctionButton.onClick.RemoveAllListeners();
        currentUI.FunctionButton.onClick.AddListener(() => UpgradeBuilding());

        if (HasUpgrades)
        {
            currentUI.DeactiveButton();
            Debug.Log("current level: " + currentLevel);
            if (currentLevel == Level1)
            {

                if (TechTreeController.Instance.isUnlocked(Level2))
                {
                    currentUI.ActivePrice(Level2.BuildingCost);
                    currentUI.ActivateButton();
                }
            }
            else if (currentLevel == Level2)
            {
                if (TechTreeController.Instance.isUnlocked(Level3))
                {
                    currentUI.ActivePrice(Level3.BuildingCost);
                    currentUI.ActivateButton();
                }
            }
        }
    }

    private void UpgradeBuilding()
    {
        if (currentLevel == Level1)
        {
            if (!MoneyController.Instance.CheckIfCanPurchase(Level2.BuildingCost))
                return;

            MoneyController.Instance.RemoveCash(Level2.BuildingCost);

            SpriteRendererO.sprite = Level2Sprite;
            currentLevel = Level2;
            foreach (ObservatoryUsage ob in Observatories)
            {
                ob.AmountToGive += 2;
            }

            foreach (RekrutacjaBuilding rk in Recrutations)
            {
                rk.AmountToGive += 5;
            }
            base.HideBuilding();
        }
        else if (currentLevel == Level2)
        {
            if (!MoneyController.Instance.CheckIfCanPurchase(Level3.BuildingCost))
                return;

            MoneyController.Instance.RemoveCash(Level3.BuildingCost);

            SpriteRendererO.sprite = Level3Sprite;

            currentLevel = Level3;
            foreach (ObservatoryUsage ob in Observatories)
            {
                ob.AmountToGive += 2;
            }

            foreach (RekrutacjaBuilding rk in Recrutations)
            {
                rk.AmountToGive += 10;
            }
            base.HideBuilding();
        }
    }

    private void OnDestroy()
    {
        foreach (ObservatoryUsage ob in Observatories)
        {
            ob.ReturnToMainValues();
        }

        foreach (RekrutacjaBuilding rk in Recrutations)
        {
            rk.ReturnToMainValues();
        }
    }
}
