using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

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

    private Sprite buildingSprite;
    private string buildingName;
    private string buildingDescription;

    private bool panelVisible = false;

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
        currentSocket.SelectedColor();
        lastSocket = currentSocket;

        lastBuildingData = buildingData;

        buildingSprite= buildingData.BuildingSprite;
        buildingName = buildingData.Header;
        buildingDescription = buildingData.Description;

        StartCoroutine(ShowPanel());
        return true;
    }

    public void DeInit()
    {
        lastSocket.UnSelect();
        lastBuildingData = null;
        lastSocket = null;
        StartCoroutine(HidePanel());
    }

    public void BuildBuilding()
    {
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
                timeElapsed += Time.deltaTime;
                yield return null;
            }
            else
            {
                objectToAnimateTransform.anchoredPosition3D = endPosition;
                objectToAnimateTransform.anchoredPosition3D = Vector3.Lerp(endPosition, StartPosition, timeElapsed / animationTime);
                timeElapsed += Time.deltaTime;
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
