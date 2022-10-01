using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] public int totalCash = 0;
    [SerializeField] public float cashGettingInterval = 1f;

    [SerializeField] public int totalResearchPoints = 0;
    [SerializeField] public int researchPointsToAdd = 0;
    [SerializeField] public float researchPointsGettingInterval = 5f;

    [SerializeField] private TMP_Text moneyText;
    [SerializeField] private TMP_Text researchPointsText;

    private void Start()
    {
        StartCoroutine(RecruitmentDepartment());
    }
    private void AddCash(int cashToAdd)
    {
        totalCash += cashToAdd;
        moneyText.text = totalCash.ToString();
    }

    private void RemoveCash(int cashToRemove)
    {
        totalCash -= cashToRemove;
        moneyText.text = totalCash.ToString();
    }

    IEnumerator RecruitmentDepartment()
    {
        yield return new WaitForSeconds(researchPointsGettingInterval);
        totalResearchPoints += researchPointsToAdd;
        StartCoroutine(RecruitmentDepartment());
        researchPointsText.GetComponent<TMP_Text>().text = "ResearchPoints: " + totalResearchPoints.ToString();
    }
}
