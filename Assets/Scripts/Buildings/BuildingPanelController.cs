using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Runtime.Serialization;

public class BuildingPanelController : Singleton<BuildingPanelController>
{
    [SerializeField]
    private Image BuildingImage;

    [SerializeField]
    private TMP_Text Header;

    [SerializeField]
    private TMP_Text Description;

    [SerializeField]
    private float animationTime;

    [SerializeField]
    private Vector3 StartPosition;

    [SerializeField]
    private Vector3 endPosition;

    [SerializeField]
    private RectTransform objectToAnimateTransform;

    [SerializeField]
    private TMP_Text price;

    [SerializeField]
    private TMP_Text buttonText;

    [SerializeField]
    private Button purchaseButton;

    private Sprite buildingSprite;
    private string buildingName;
    private string buildingDescription;

    private bool panelVisible = false;

    private bool blockBuilding = false;

    public bool BlockBuilding { get => blockBuilding; set => blockBuilding = value; }

    private BuildingScriptableObject lastBuildingData;

    private Coroutine showingCoroutine = null;

    private BuildingSocket lastSocket = null;

    public bool Init(BuildingScriptableObject buildingData, BuildingSocket currentSocket)
    {

        if(currentSocket == lastSocket)
        {
            currentSocket.UnSelect();
            DeInit();
            return false;
        }

        if (panelVisible && lastBuildingData == buildingData)
        {
            lastSocket.UnSelect();
            lastSocket = currentSocket;
            return true;
        }
        else if(panelVisible)
        {
            lastSocket.UnSelect();
            DeInit();
        }

        ClosePopups.Instance.CloseWithoutOne(this);

        currentSocket.SelectedColor();
        lastSocket = currentSocket;

        lastBuildingData = buildingData;

        buildingSprite= buildingData.BuildingSprite;
        buildingName = buildingData.Header;
        buildingDescription = buildingData.Description;
        price.text = buildingData.Price.ToString();

        if (!TechTreeController.Instance.isUnlocked(lastSocket.FirstLevelData))
        {
            purchaseButton.interactable = false;
        }
        else
        {
            purchaseButton.interactable = true;
        }

        StartCoroutine(ShowPanel());
        return true;
    }

    public void DeInit()
    {
        if (lastSocket == null)
            return;
        lastSocket.UnSelect();
        lastBuildingData = null;
        lastSocket = null;
        StartCoroutine(HidePanel());
    }

    public void BuildBuilding()
    {
        if (!MoneyController.Instance.CheckIfCanPurchase(lastBuildingData.Price))
            return;

        if (blockBuilding)
            return;

        MoneyController.Instance.RemoveCash(lastBuildingData.Price);
        lastSocket.BuildBuilding();
        DeInit();
    }

    private IEnumerator ShowPanel()
    {
        if (showingCoroutine != null)
        {
            yield return new WaitUntil(() => showingCoroutine == null);
        }
        panelVisible = true;
        showingCoroutine = StartCoroutine(Animation(true));
        
    }

    private IEnumerator HidePanel()
    {
        if (showingCoroutine != null)
        {
            yield return new WaitUntil(() => showingCoroutine == null);
        }

        showingCoroutine = StartCoroutine(Animation(false));
    }

    private IEnumerator Animation(bool show)
    {
        float timeElapsed = 0;
        while (timeElapsed < animationTime)
        {
            if (show)
            {
                BuildingImage.sprite = buildingSprite;
                Header.text = buildingName;
                Description.text = buildingDescription; 
                objectToAnimateTransform.anchoredPosition3D = StartPosition;
                objectToAnimateTransform.anchoredPosition3D = Vector3.Lerp(StartPosition, endPosition, timeElapsed / animationTime);
                timeElapsed += Time.unscaledDeltaTime;
                yield return null;
            }
            else
            {
                objectToAnimateTransform.anchoredPosition3D = endPosition;
                objectToAnimateTransform.anchoredPosition3D = Vector3.Lerp(endPosition, StartPosition, timeElapsed / animationTime);
                timeElapsed += Time.unscaledDeltaTime;
                panelVisible = false;
                yield return null;
            }
        }

        if (show)
            objectToAnimateTransform.anchoredPosition3D = endPosition;
        else
            objectToAnimateTransform.anchoredPosition3D = StartPosition;


        showingCoroutine = null;
    }
}
