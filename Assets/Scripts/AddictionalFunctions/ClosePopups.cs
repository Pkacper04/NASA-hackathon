using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePopups : Singleton<ClosePopups>, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        BuildingController.Instance.HideBuildingInfo();
        BuildingPanelController.Instance.DeInit();
        TechTreeController.Instance.DisavleTechTreeUI();
    }

    public void CloseAllPanels()
    {
        BuildingController.Instance.HideBuildingInfo();
        BuildingPanelController.Instance.DeInit();
        TechTreeController.Instance.DisavleTechTreeUI();
    }

    public void CloseWithoutOne(BuildingPanelController panelController)
    {
        BuildingController.Instance.HideBuildingInfo();
        TechTreeController.Instance.DisavleTechTreeUI();
    }

    public void CloseWithoutOne(BuildingController panelController)
    {
        BuildingPanelController.Instance.DeInit();
        TechTreeController.Instance.DisavleTechTreeUI();
    }

    public void CloseWithoutOne(TechTreeController panelController)
    {
        BuildingController.Instance.HideBuildingInfo();
        BuildingPanelController.Instance.DeInit();
    }

}
