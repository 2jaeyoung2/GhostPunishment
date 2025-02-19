using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable, IScoreable
{
    [SerializeField]
    private float playerHP;

    [SerializeField]
    private float playerEXP;

    void Start()
    {
        playerHP = 100f;

        playerEXP = 0f;
    }

    public void GetDamage(float damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            Debug.Log("Dead");

            Die();
        }
    }

    public void GetExp(float exp)
    {
        playerEXP += exp;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
