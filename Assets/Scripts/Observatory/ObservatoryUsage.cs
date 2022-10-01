using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservatoryUsage : buildingFunctionality
{
    [SerializeField]
    private int amountToGive;

    [SerializeField]
    private float timeToGive;

    [SerializeField]
    private int buildingLevel = 1;

    private float time = 0;

    public int AmountToGive { get => amountToGive; set => amountToGive = value; }


    private void Start()
    {
        base.Start();
        time = timeToGive;
    }

    public override void DisplayBuilding()
    {
        base.DisplayBuilding();
        currentUI.FunctionButton.onClick.AddListener(() => UpgradeBuilding());
    }

    private void UpgradeBuilding()
    {
        buildingLevel++;
        Debug.Log("building upgraded: "+buildingLevel);
    }

    private void Update()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            time = timeToGive;
            Debug.Log("Add RP");
;            //adding amount
        }
    }
}
