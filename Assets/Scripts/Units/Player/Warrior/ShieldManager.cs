using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public event Action<float> OnDamageChanged;

    public Player player;

    private float damage;

    private void Start()
    {
        player.OnLevelChanged += IncreaseDamage;

        damage = 10f;
    }

    private void IncreaseDamage()
    {
        damage *= 1.1f;

        OnDamageChanged?.Invoke(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<IDamageable>()?.GetDamage(damage);
        }
    }
}
