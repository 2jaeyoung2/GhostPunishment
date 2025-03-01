using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackMagician : MonoBehaviour
{
    [SerializeField]
    private float coolTime;

    private float tempCoolTime;

    [SerializeField]
    [Range(3, 6)]
    private int cardNumber;

    private void Start()
    {
        coolTime = 2f;

        tempCoolTime = coolTime / 2;

        cardNumber = 4;
    }

    void Update()
    {
        tempCoolTime -= Time.deltaTime;

        if (tempCoolTime <= 0f)
        {
            StartCoroutine(ThrowCards(cardNumber));

            tempCoolTime = coolTime;
        }
    }

    IEnumerator ThrowCards(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var card = CardPoolManager.Instance.GetCard();

            card.GetComponent<Card>().player = gameObject.GetComponent<Player>();

            SoundManager.Instance.PlayCardThrowingSound();

            card.transform.position = gameObject.transform.position + new Vector3(0, 0.2f, 0);

            yield return new WaitForSeconds(0.2f);
        }
    }
}