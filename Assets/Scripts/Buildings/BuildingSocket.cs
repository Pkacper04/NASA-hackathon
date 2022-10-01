using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildingSocket : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private BuildingTypes buildingType;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Color inActiveColor;

    [SerializeField]
    private Color activeColor;

    [SerializeField]
    private Color selectedColor;

    [SerializeField]
    private Vector3 positionOffset;

    private bool selected = false;

    public bool Selected { get => selected; set => selected = value; }

    public BuildingTypes BuildingType { get => buildingType; set => buildingType = value; }

/*    private void OnEnable()
    {
        PlayerEvents.Instance.OnPlayerMouseDown += Pointer;
    }

    private void OnDisable()
    {
        if(PlayerEvents.Instance != null)
            PlayerEvents.Instance.OnPlayerMouseDown -= Pointer;
    }*/

    public void Pointer()
    {
        if (!selected)
            return;
        BuildingPanelController.Instance.DeInit();
        selected = false;
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        BuildingScriptableObject buildingData = BuildingController.Instance.GetBuildingData(buildingType);
        if(buildingData == null)
        {
            Debug.LogError("building data is null");
            return;
        }

        selected = BuildingPanelController.Instance.Init(buildingData, this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (selected)
            return;

        spriteRenderer.color = activeColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (selected)
            return;

        spriteRenderer.color = inActiveColor;
    }

    public void SelectedColor()
    {
        selected = true;
        spriteRenderer.color = selectedColor;
    }

    public void BuildBuilding()
    {
        BuildingScriptableObject buildingData = BuildingController.Instance.GetBuildingData(buildingType);
        Instantiate(buildingData.BuildingPrefab, transform.position + positionOffset, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void UnSelect()
    {
        selected = false;
        spriteRenderer.color = inActiveColor;
    }
}

