using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject shield;

    private GameObject tempShield;

    [SerializeField]
    private float coolTime;

    private float tempCooltime;

    private void Start()
    {
        coolTime = 6f;

        tempCooltime = 3f;

        tempShield = Instantiate(shield, transform.position + new Vector3(0, 0.2f, 0.3f), transform.rotation);

        tempShield.SetActive(false);
    }

    private void Update()
    {
        tempCooltime -= Time.deltaTime;

        if (tempCooltime <= 0)
        {
            ThrowShield();

            tempCooltime = coolTime;
        }
    }

    void ThrowShield()
    {
        tempShield.SetActive(true);
    }
}
