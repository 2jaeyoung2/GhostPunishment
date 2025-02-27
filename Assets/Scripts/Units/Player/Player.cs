using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable, IExp, IHeal
{
    public event Action<float, float> OnHealthChanged;

    public event Action<float, float> OnEXPChanged;

    public event Action OnGetHP;

    public event Action OnLevelChanged;

    [SerializeField]
    private float playerMaxHP;

    private float currentHP;

    [SerializeField]
    private float currentPlayerEXP;

    private int level;

    void Start()
    {
        playerMaxHP = 25f;

        currentHP = playerMaxHP;

        level = 1;

        currentPlayerEXP = 0f;

        OnHealthChanged?.Invoke(currentHP, playerMaxHP);

        OnEXPChanged?.Invoke(currentPlayerEXP, RequiredExp(level));
    }

    public void GetDamage(float damage)
    {
        currentHP -= damage;

        OnHealthChanged?.Invoke(currentHP, playerMaxHP);

        if (currentHP <= 0)
        {
            Debug.Log("Dead");

            currentHP = 0;

            OnHealthChanged?.Invoke(currentHP, playerMaxHP);

            Die();
        }
    }

    public void GetHealth(float heal)
    {
        if (currentHP < playerMaxHP)
        {
            currentHP += heal;

            if (currentHP > playerMaxHP)
            {
                currentHP = playerMaxHP;
            }
        }

        OnHealthChanged?.Invoke(currentHP, playerMaxHP);

        OnGetHP?.Invoke();
    }

    public void GetExp(float exp)
    {
        currentPlayerEXP += exp;

        // 레벨 업
        if (currentPlayerEXP >= RequiredExp(level))
        {
            level++;

            OnLevelChanged?.Invoke();
        }

        OnEXPChanged?.Invoke(currentPlayerEXP, RequiredExp(level));
    }

    public void Die()
    {
        gameObject.SetActive(false);
    }

    public float RequiredExp(int level) // 현재 레벨에 따른 레벨업 요구 경험치 량
    {
        if (level == 1) return 10f;

        if (level == 2) return 25f;

        return RequiredExp(level - 1) + RequiredExp(level - 2);
    }
}
