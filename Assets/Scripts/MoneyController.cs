using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] public int totalCash = 0;
    [SerializeField] public int cashToAdd = 0;
    [SerializeField] public float cashGettingInterval = 5f;

    [SerializeField] public int totalResearchPoints = 0;
    [SerializeField] public int researchPointsToAdd = 0;

    private void Start()
    {
        StartCoroutine(observatory());
    }
    IEnumerator observatory()
    {
        yield return new WaitForSeconds(cashGettingInterval);
        totalCash += cashToAdd;
        StartCoroutine(observatory());
    }
}
