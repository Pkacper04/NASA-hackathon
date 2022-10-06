using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorMovement : MonoBehaviour
{

    [SerializeField]
    private Vector3 movementValue;

    [SerializeField]
    private float animationTime;

    private float currentTime;

    private Vector3 startScale;

    private Vector3 endScale;

    // Start is called before the first frame update
    void Start()
    {
        endScale = transform.localScale + movementValue;
        StartCoroutine(AnimationMove());
    }

    private IEnumerator AnimationMove()
    {
        currentTime = 0;
        startScale = transform.localScale;

        while(currentTime < animationTime)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, currentTime/animationTime);
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = endScale;
        currentTime = 0;

        while(currentTime < animationTime)
        {
            transform.localScale = Vector3.Lerp(endScale, startScale, currentTime / animationTime);
            currentTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = startScale;
        StartCoroutine(AnimationMove());
    }
}
