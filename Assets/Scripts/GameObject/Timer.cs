using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<float, float> OnTimeChanged;

    private float totalTime;

    private float currentTime;

    private float timeSpeed;

    public bool isEnd;

    private void Awake()
    {
        isEnd = false;

        totalTime = 180f;

        timeSpeed = 1f;
    }

    private void Start()
    {
        StartCoroutine(TimeFlow());
    }

    IEnumerator TimeFlow()
    {
        currentTime = 0;

        while (currentTime < totalTime)
        {
            currentTime += Time.deltaTime * timeSpeed;

            if (currentTime >= totalTime)
            {
                isEnd = true;

                yield break;
            }

            OnTimeChanged?.Invoke(currentTime, totalTime);

            yield return null;
        }
    }

    public void SetTimeSpeed(float speed)
    {
        timeSpeed = speed;
    }
}
