using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackMagician : MonoBehaviour
{
    [SerializeField]
    private GameObject card;

    [SerializeField]
    private float cooltime;

    [SerializeField]
    [Range(3, 6)]
    private int cardNumber;

    private void Start()
    {
        cooltime = 3f;

        cardNumber = 3;
    }

    void Update()
    {
        cooltime -= Time.deltaTime;

        if (cooltime <= 0f)
        {
            StartCoroutine(ThroughCards(cardNumber));

            cooltime = 3f;
        }
    }

    IEnumerator ThroughCards(int count)
    {
        for (int i = count; i > 0; i--)
        {
            Instantiate(card, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);

            yield return new WaitForSeconds(0.3f);
        }
    }
}