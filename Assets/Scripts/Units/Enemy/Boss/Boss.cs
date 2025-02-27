using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Phase
{
    Blue, Pink, Red, Dead
}

public class Boss : Enemy
{
    public event Action<float, float> OnHealthChanged;

    public event Action<Phase> OnPhaseChanged;

    Phase bossPhase;

    protected override float EnemyHP { get => base.EnemyHP; set => base.EnemyHP = value; }

    protected override float MoveSpeed { get => base.MoveSpeed; set => base.MoveSpeed = value; }

    private float bossCurrentHP;

    private GameObject tempHealgem;

    protected override void Start()
    {
        EnemyHP = 300f;

        bossCurrentHP = EnemyHP;

        MoveSpeed = 0.3f;

        enemyState = EnemyState.Follow;
    }

    protected override void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Follow:

                Move();

                break;

            case EnemyState.Attack:

                // TODO: 공격 로직

                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyState = EnemyState.Attack;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemyState = EnemyState.Follow;
        }
    }

    public override void GetDamage(float damage)
    {
        bossCurrentHP -= damage;

        if (EnemyHP * (2f / 3f) > bossCurrentHP && bossCurrentHP >= EnemyHP / 3f)
        {
            bossPhase = Phase.Pink;
        }
        if(EnemyHP / 3f > bossCurrentHP && bossCurrentHP > 0)
        {
            bossPhase = Phase.Red;
        } 
        if( 0 >= bossCurrentHP)
        {
            bossPhase = Phase.Dead;
        }

        OnHealthChanged?.Invoke(bossCurrentHP, EnemyHP);

        OnPhaseChanged?.Invoke(bossPhase);

        if (bossCurrentHP <= 0)
        {
            bossCurrentHP = 0;

            OnHealthChanged?.Invoke(bossCurrentHP, EnemyHP);

            Die();
        }
    }

    public override void Die()
    {
        DropHEAL();

        DropEXP();

        StartCoroutine(GoToHell());
    }

    IEnumerator GoToHell()
    {
        CapsuleCollider colliderToDel = gameObject.GetComponent<CapsuleCollider>();

        Destroy(colliderToDel);

        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        rb.useGravity = false;

        playerToChase = null;

        while (gameObject.transform.position.y > -2.7f)
        {
            gameObject.transform.Translate(Vector3.down * MoveSpeed * Time.deltaTime);

            yield return null;
        }

        Destroy(gameObject);
    }

    public override void DropEXP()
    {
        expToDrop = GemPoolManager.Instance.GetGem();

        expToDrop.transform.position = transform.position;
    }

    public override void DropHEAL()
    {
        tempHealgem = Instantiate(healToDrop, transform.position, Quaternion.LookRotation(Vector3.forward));

        tempHealgem.transform.position = transform.position;
    }
}