using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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


    public Image BuildingIcon { get => buildingIcon; set =>buildingIcon = value; }
    public TMP_Text Header { get => header; set => header = value; }
    public TMP_Text Description { get => description; set => description = value; }
    public Button SellButton { get => sellButton; set => sellButton = value; }
    public Button FunctionButton { get => functionButton; set => functionButton = value; }

    public void SetDecors(Sprite buildingSprite, string header, string description)
    {
        buildingIcon.sprite = buildingSprite;
        this.header.text = header;
        this.description.text = description;
    }
}
