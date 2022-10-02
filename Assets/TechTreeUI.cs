using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TechTreeUI : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup TechtreeGroup;

    [SerializeField]
    private CanvasGroup SateliteGroup;

    [SerializeField]
    private CanvasGroup BuildingsGroup;

    [SerializeField]
    private CanvasGroup MainGroup;

    public void DisplaySateliteUpgrades()
    {
        SateliteGroup.alpha = 1;
        SateliteGroup.blocksRaycasts = true;
        SateliteGroup.interactable = true;
        HideBuildingsUpgrades();
        HideMainUpgrades();
    }

    public void DisplayBuildingsUpgrades()
    {
        BuildingsGroup.alpha = 1;
        BuildingsGroup.blocksRaycasts = true;
        BuildingsGroup.interactable = true;
        HideSateliteUpgrades();
        HideMainUpgrades();
    }

    public void DisplayMainUpgrades()
    {
        MainGroup.alpha = 1;
        MainGroup.blocksRaycasts = true;
        MainGroup.interactable = true;
        HideSateliteUpgrades();
        HideBuildingsUpgrades();
    }

    private void HideSateliteUpgrades()
    {
        SateliteGroup.alpha = 0;
        SateliteGroup.blocksRaycasts = false;
        SateliteGroup.interactable = false;
    }

    private void HideBuildingsUpgrades()
    {
        BuildingsGroup.alpha = 0;
        BuildingsGroup.blocksRaycasts = false;
        BuildingsGroup.interactable = false;
    }

    public void HideMainUpgrades()
    {
        MainGroup.alpha = 0;
        MainGroup.blocksRaycasts = false;
        MainGroup.interactable = false;
    }

    public void EnableTechTree()
    {
        TechtreeGroup.alpha = 1;
        TechtreeGroup.blocksRaycasts = true;
        TechtreeGroup.interactable = true;
    }

    public void DisableTechTree()
    {
        TechtreeGroup.alpha = 0;
        TechtreeGroup.blocksRaycasts = false;
        TechtreeGroup.interactable = false;
    }

    public bool TechtreeActive()
    {
        return TechtreeGroup.interactable;
    }
}
