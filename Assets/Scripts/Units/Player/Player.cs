using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IScoreable
{
    public event Action<float, float> OnHealthChanged;

    public event Action<float, float> OnEXPChanged;

    [SerializeField]
    private float playerMaxHP;

    private float currentHP;

    [SerializeField]
    private float currentPlayerEXP;

    private int level;

    void Start()
    {
        playerMaxHP = 100f;

        currentHP = playerMaxHP;

        level = 1;

        currentPlayerEXP = 0f;

        //OnHealthChanged?.Invoke(currentHP, playerMaxHP);

        OnEXPChanged?.Invoke(currentPlayerEXP, RequiredExp(level));
    }

    public void GetDamage(float damage)
    {
        currentHP -= damage;

        OnHealthChanged?.Invoke(currentHP, playerMaxHP);

        if (currentHP <= 0)
        {
            Debug.Log("Dead");

            Die();
        }
    }

    public void GetExp(float exp)
    {
        currentPlayerEXP += exp;

        if (currentPlayerEXP >= RequiredExp(level))
        {
            level++;
        }

        OnEXPChanged?.Invoke(currentPlayerEXP, RequiredExp(level));
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public float RequiredExp(int level)
    {
        if (level == 1) return 10f;
        if (level == 2) return 25f;

        return RequiredExp(level - 1) + RequiredExp(level - 2);
    }
}
