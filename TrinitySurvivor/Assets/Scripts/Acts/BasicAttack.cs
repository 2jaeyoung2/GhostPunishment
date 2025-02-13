using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject card;

    private float cooltime;

    private int CardNumber { get; set; }

    private void Start()
    {
        cooltime = 3f;

        CardNumber = 3;
    }

    void Update()
    {
        cooltime -= Time.deltaTime;

        if (cooltime <= 0f)
        {
            StartCoroutine(ThroughCards(CardNumber));

            cooltime = 3f;
        }
    }

    IEnumerator ThroughCards(int count)
    {
        for (int i = count; i > 0; i--)
        {
            Instantiate(card, transform.position,transform.rotation);

            yield return new WaitForSeconds(0.3f);
        }
    }
}