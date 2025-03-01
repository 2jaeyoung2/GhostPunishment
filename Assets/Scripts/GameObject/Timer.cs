using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<float, float> OnTimeChanged;

    public event Action IsTimeEnd;

    private float totalTime;

    private float currentTime;

    [SerializeField]
    [Range(1f, 10f)]
    private float timeSpeed;

    public bool isEnd;

    private void Awake()
    {
        isEnd = false;

        totalTime = 2f;

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

                IsTimeEnd?.Invoke();

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
