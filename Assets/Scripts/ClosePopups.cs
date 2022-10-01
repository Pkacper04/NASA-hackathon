using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePopups : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("zamykanie");
        BuildingController.Instance.HideBuildingInfo();
        BuildingPanelController.Instance.DeInit();
        TechTreeController.Instance.DisavleTechTreeUI();
    }


}
