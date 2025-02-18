using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhostAttackMove : MonoBehaviour
{
    [SerializeField]
    [Range(1f, 3f)]
    private float moveSpeed;

    void Start()
    {
        moveSpeed = 1.5f;
    }

    void Update()
    {
        BooMove();
    }

    void BooMove()
    {
        gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 1f);
    }
}
