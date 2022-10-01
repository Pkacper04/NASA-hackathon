using Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPointer : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            PlayerEvents.Instance.CallOnPlayerMouseDown();
        }
    }
}
