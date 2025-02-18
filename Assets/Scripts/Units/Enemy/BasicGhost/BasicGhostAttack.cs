using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhostAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject basicGhostProjectile;

    [SerializeField]
    private float cooltime;

    private float tempCoolTime;

    void Start()
    {
        cooltime = 2.6f;

        tempCoolTime = cooltime;
    }

    void Update()
    {
        tempCoolTime -= Time.deltaTime;

        if (tempCoolTime <= 0)
        {
            Boo();
            tempCoolTime = cooltime;
        }
    }

    private void Boo()
    {
        Instantiate(basicGhostProjectile, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        Debug.Log("boo");
    }
}
