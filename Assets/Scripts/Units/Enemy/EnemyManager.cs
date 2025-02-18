using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour, IDamageable
{
    [SerializeField]
    protected GameObject playerToChase;

    [SerializeField]
    protected float enemyHP;

    protected virtual float EnemyHP
    {
        get
        {
            return enemyHP;
        }
        set
        {
            enemyHP = value;
        }
    }

    protected float moveSpeed;

    protected abstract void Start();

    protected abstract void Update();

    protected void FixedUpdate()
    {
        FaceToPlayer(playerToChase);
    }

    protected void FaceToPlayer(GameObject player)
    {
        transform.LookAt(player.transform.position);
    }

    public virtual void GetDamage(float damage)
    {
        EnemyHP -= damage;

        if (enemyHP <= 0)
        {
            Debug.Log("Dead");
            Die();
        }
    }

    public abstract void Die();
}
