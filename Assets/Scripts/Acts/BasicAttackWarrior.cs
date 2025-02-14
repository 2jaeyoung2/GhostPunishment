using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackWarrior : MonoBehaviour
{
    [SerializeField]
    private GameObject sword;

    [SerializeField]
    private float cooltime;

    int i = 0;

    void Start()
    {
        cooltime = 3f;
    }

    void Update()
    {
        cooltime -= Time.deltaTime;

        if (cooltime <= 0)
        {
            SweepSword();
            cooltime = 2f;
        }
    }

    void SweepSword()
    {
        GameObject tempSword = Instantiate(sword, transform.position + new Vector3(0, 0.2f, 0), transform.rotation);
        tempSword.transform.SetParent(transform);
        Debug.Log(i++);
        Destroy(tempSword, 2f);
    }
}
