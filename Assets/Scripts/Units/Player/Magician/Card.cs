using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField]
    [Range(2f, 10f)]
    private float moveSpeed;

    [SerializeField]
    private float damage;

    private float duration;

    private void Awake()
    {
        moveSpeed = 5f;

        damage = 10f;

        duration = 3f;
    }

    private void OnEnable()
    {
        StartCoroutine(CardMove());
    }

    IEnumerator CardMove()
    {
        while (duration - Time.deltaTime > 0)
        {
            gameObject.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            yield return null;

            StartCoroutine(ClearCard());
        }
    }

    IEnumerator ClearCard()
    {
        yield return new WaitForSeconds(4f);

        CardPoolManager.Instance.ReturnCard(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<IDamageable>()?.GetDamage(damage);

            CardPoolManager.Instance.ReturnCard(this);
        }
    }
}
