using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMovement : MonoBehaviour
{
    [SerializeField]
    [Range(2f, 10f)]
    private float moveSpeed;

    private float duration;

    private void Start()
    {
        moveSpeed = 5f;

        duration = 4f;

        StartCoroutine(CardMove());
    }

    IEnumerator CardMove()
    {
        while (duration - Time.deltaTime > 0)
        {
            gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            yield return null;
        }

        Destroy(gameObject);
    }
}
