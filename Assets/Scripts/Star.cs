using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using NaughtyAttributes;

public class Star : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [SerializeField]
    private Image loadingImage;

    private float timeSearched;


    bool startSearching = false;

    bool objectFound = false;

    [ReadOnly]
    public PlanetsScriptableData starData;
    public PlanetsScriptableData StarData { get => starData; set => starData = value; }

    public void OnPointerDown(PointerEventData eventData)
    {
        timeSearched = 0;
        startSearching = true;
    }

    private void Update()
    {
        if (startSearching && !objectFound)
        {
            if (timeSearched >= MinigameController.Instance.DetectingTime)
            {

                ObjectFound();
                return;
            }
            timeSearched += Time.deltaTime;
            loadingImage.fillAmount = timeSearched / MinigameController.Instance.DetectingTime;
            
        }
    }

    private void ObjectFound()
    {
        if (objectFound)
            return;

        objectFound = true;
        loadingImage.fillAmount = 0;
        MinigameController.Instance.FoundStar(StarData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        startSearching = false;
        timeSearched = 0;
        loadingImage.fillAmount = 0;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startSearching = false;
        timeSearched = 0;
        loadingImage.fillAmount = 0;
    }
}
