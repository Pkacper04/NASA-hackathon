using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeData : MonoBehaviour
{
    [SerializeField]
    private ResearchData currentResearchData;

    [SerializeField]
    private Button objectButton;

    [SerializeField]
    private TMP_Text buttonText;

    public ResearchData CurrentResearchData { get => currentResearchData; set => currentResearchData = value; }

    public Button ObjectButton { get => objectButton; set => objectButton = value; }

    public TMP_Text ButtonText { get => buttonText; set => buttonText = value; }
}
