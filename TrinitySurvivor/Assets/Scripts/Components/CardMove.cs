using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    [SerializeField]
    [Range(2f, 10f)]
    private float moveSpeed;

    private void Start()
    {
        moveSpeed = 5f;
    }

    void Update()
    {
        ThrowCard();
    }

    void ThrowCard()
    {
        gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        Destroy(gameObject, 4f);
    }
}
