using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour, IDamageable
{
    [SerializeField]
    private float playerHP;

    void Start()
    {
        playerHP = 100f;
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

    public void Die()
    {
        Destroy(gameObject);
    }
}
