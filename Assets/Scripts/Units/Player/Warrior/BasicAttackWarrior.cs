using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackWarrior : MonoBehaviour
{
    [SerializeField]
    private GameObject sword;

    [SerializeField]
    private float coolTime;

    private float tempCoolTime;

    private float rotateSpeed;

    private float duration;

    private GameObject tempSword;

    void Start()
    {
        coolTime = 3f;

        tempCoolTime = coolTime / 2;

        rotateSpeed = 720f;

        tempSword = Instantiate(sword, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);

        tempSword.SetActive(false);
    }

    void Update()
    {
        tempCoolTime -= Time.deltaTime;

        if (tempCoolTime <= 0)
        {
            SweepSword();

            tempCoolTime = coolTime;
        }
    }

    void SweepSword()
    {
        tempSword.transform.position = transform.position + new Vector3(0, 0.2f, 0);

        tempSword.SetActive(true);

        tempSword.transform.SetParent(null);

        StartCoroutine(RotateSword(tempSword));
    }

    IEnumerator RotateSword(GameObject swordObj) // TODO: 회전 로직 나중에 다시 수정
    {
        // rotateSpeed * duration = 360 가 되어야 함.

        rotateSpeed = 1440f;

        duration = 0.25f;

        float timeElapsed = 0f;

        while (timeElapsed <= duration)
        {
            swordObj.transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);

            timeElapsed += Time.deltaTime;

            yield return null;
        }

        tempSword.SetActive(false);
    }
}
