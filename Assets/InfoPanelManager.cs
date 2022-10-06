using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InfoPanelManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text notificationHeader;

    [SerializeField]
    private TMP_Text notificationDescription;

    [SerializeField]
    private Button okButton;

    public Button OkButton { get => okButton; set => okButton = value; }


    public void SetInfo(string header, string description)
    {
        notificationHeader.text = header;
        notificationDescription.text = description;
    }

}
