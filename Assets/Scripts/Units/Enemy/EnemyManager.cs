using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyManager : MonoBehaviour, IDamageable
{
    protected float EnemyHP;

    protected float moveSpeed;

    public abstract void Start();

    public abstract void Update();

    public abstract void GetDamage(float damage);
}
