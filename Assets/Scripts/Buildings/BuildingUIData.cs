using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class BuildingUIData : MonoBehaviour
{

    [SerializeField]
    private Image buildingIcon;

    [SerializeField]
    private TMP_Text header;

    [SerializeField]
    private TMP_Text description;

    [SerializeField]
    private Button sellButton;

    [SerializeField]
    private Button functionButton;

    [SerializeField]
    private TMP_Text functionButtonText;

    [SerializeField]
    private GameObject priceGameObject;

    [SerializeField]
    private TMP_Text priceText;



    public Image BuildingIcon { get => buildingIcon; set =>buildingIcon = value; }
    public TMP_Text Header { get => header; set => header = value; }
    public TMP_Text Description { get => description; set => description = value; }
    public Button SellButton { get => sellButton; set => sellButton = value; }
    public Button FunctionButton { get => functionButton; set => functionButton = value; }
    public TMP_Text FunctionButtonText { get => functionButtonText; set => functionButtonText = value; }

    public void SetDecors(Sprite buildingSprite, string header, string description)
    {
        buildingIcon.sprite = buildingSprite;
        this.header.text = header;
        this.description.text = description;
    }

    public void SellBuilding()
    {

        buildingFunctionality lastBuilding = BuildingController.Instance.LastBuilding;
        BuildingScriptableObject buildingData = BuildingController.Instance.GetBuildingData(lastBuilding.BuildingType);
        MoneyController.Instance.AddCash(buildingData.Price);

        lastBuilding.Socket.gameObject.SetActive(true);

        BuildingController.Instance.HideBuildingInfo();

        Destroy(lastBuilding.gameObject);
    }

    public void ActivePrice(int price)
    {
        priceText.text = price.ToString();
        priceGameObject.SetActive(true);
    }

    public void DeactiveButton()
    {
        FunctionButton.gameObject.SetActive(false);
    }

    public void ActivateButton()
    {
        FunctionButton.gameObject.SetActive(true);
    }
}
