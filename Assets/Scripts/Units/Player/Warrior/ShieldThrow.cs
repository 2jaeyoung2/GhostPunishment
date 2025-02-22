using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    [SerializeField]
    private GameObject shield;

    [SerializeField]
    private float cooltime;

    private float tempCooltime;

    private void Start()
    {
        cooltime = 6f;

        tempCooltime = 3f;
    }

    private void Update()
    {
        tempCooltime -= Time.deltaTime;

        if (tempCooltime <= 0)
        {
            ThrowShield();

            tempCooltime = cooltime;
        }
    }

    void ThrowShield()
    {
        Instantiate(shield, transform.position + new Vector3(0, 0.2f, 0.3f), transform.rotation);
    }
}
