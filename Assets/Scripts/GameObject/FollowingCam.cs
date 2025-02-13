using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FollowingCam : MonoBehaviour
{
    [SerializeField]
    private Transform cameraPos;

    [SerializeField]
    private Transform targetToFollow;

    [SerializeField]
    [Range(0f, 20.0f)]
    private float distance;

    [SerializeField]
    [Range(0, 10.0f)]
    private float height;

    private void Start()
    {
        distance = 2.8f;
        height = 7f;
    }

    void LateUpdate()
    {
        if (targetToFollow.hasChanged)
        {
            cameraPos.position = targetToFollow.position + (Vector3.up * height) + (Vector3.forward * -distance);
        }
    }
}
