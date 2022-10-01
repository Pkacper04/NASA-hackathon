using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePopups : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        BuildingController.Instance.HideBuildingInfo();
        BuildingPanelController.Instance.DeInit();
    }


}
