using Events;
using Game.SaveLoadSystem;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class buildingFunctionality : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    protected BuildingUIData buildingPanel;

    [SerializeField]
    protected BuildingTypes buildingType;

    [SerializeField]
    private Vector3 infoOffset;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Color activeColor;

    [SerializeField]
    private Color inActiveColor;

    [SerializeField]
    private Color selectedColor;

    private BuildingSocket socket;

    protected BuildingScriptableObject buildingData = null;

    protected BuildingUIData currentUI = null;

    public BuildingTypes BuildingType { get => buildingType; set => buildingType = value; }

    private Vector3 offset;

    public BuildingSocket Socket { get => socket; set => socket = value; }

    public SpriteRenderer SpriteRendererO { get => spriteRenderer; set => spriteRenderer = value; }
    public Vector3 Offset { get => offset; set => offset = value; }

    protected ResearchData currentLevel;

    public ResearchData CurrentLevel { get => currentLevel; set => currentLevel = value; }


    public virtual void ChangeCurrentLevel(int level)
    {
        
    }

    protected virtual void Start()
    {
        buildingData = BuildingController.Instance.GetBuildingData(buildingType);
        buildingPanel = FindObjectOfType<BuildingUIData>(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(BuildingController.Instance.DisplayBuildingInfo(this))
        {
            DisplayBuilding();
        }
        else
        {
            HideBuilding();
        }
    }

    public virtual void DisplayBuilding()
    {
        GameObject generatedObject = Instantiate(buildingPanel.gameObject, transform.position + infoOffset, Quaternion.identity);
        currentUI = generatedObject.GetComponent<BuildingUIData>();
        currentUI.SetDecors(buildingData.BuildingSprite, Language.Instance.GetTranslation(buildingData.Header), Language.Instance.GetTranslation(buildingData.Description));
        generatedObject.SetActive(true);
        SelectedColor();
    }

    public virtual void HideBuilding()
    {
        if (currentUI != null)
        {
            Destroy(currentUI.gameObject);
            currentUI = null;
            UnSelect();
        }
    }

    protected virtual void SetBuildingDecorData()
    {
        BuildingScriptableObject buildingData = BuildingController.Instance.GetBuildingData(buildingType);
        buildingPanel.SetDecors(buildingData.BuildingSprite, Language.Instance.GetTranslation(buildingData.Header), Language.Instance.GetTranslation(buildingData.Description));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (currentUI != null)
            return;

        spriteRenderer.color = activeColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (currentUI != null)
            return;

        spriteRenderer.color = inActiveColor;
    }

    protected void SelectedColor()
    {
        spriteRenderer.color = selectedColor;
    }

    protected void UnSelect()
    {
        spriteRenderer.color = inActiveColor;
    }

}
