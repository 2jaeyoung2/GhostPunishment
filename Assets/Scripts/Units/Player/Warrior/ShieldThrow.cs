using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldThrow : MonoBehaviour
{
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

        tempShield.GetComponent<ShieldManager>().player = gameObject.GetComponent<Player>();

        tempShield.SetActive(false);
    }

    private void Update()
    {
        tempCooltime += Time.deltaTime;

        if (tempCooltime >= coolTime)
        {
            ThrowShield();

            tempCooltime = 0;
        }
    }

    void ThrowShield()
    {
        tempShield.transform.position = gameObject.transform.position + new Vector3(0, 0.2f, 0.3f);

        tempShield.SetActive(true);
    }
}
