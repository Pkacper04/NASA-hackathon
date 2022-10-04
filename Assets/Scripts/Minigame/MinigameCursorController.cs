using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCursorController : MonoBehaviour
{

    [SerializeField]
    private GameObject lightPointer;

    [SerializeField]
    private MinigameController controller;

    [SerializeField]
    private Camera maincamera;



    // Update is called once per frame
    void Update()
    {
        if (EscMenuController.GamePaused)
            return;

        if (controller.GameStarted)
        {
            lightPointer.transform.position = maincamera.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}
