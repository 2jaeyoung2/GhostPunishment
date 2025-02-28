using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhost : Enemy
{
    protected override float EnemyHP { get => base.EnemyHP; set => base.EnemyHP = value; }

    protected override float MoveSpeed { get => base.MoveSpeed; set => base.MoveSpeed = value; }

    [SerializeField]
    private GameObject basicGhostProjectile;

    private GameObject tempHealgem;

    [SerializeField]
    private float coolTime;

    private float tempCoolTime;
     
    protected override void Start()
    {
        EnemyHP = 30f;

        MoveSpeed = 0.8f;

        coolTime = 2.6f;

        tempCoolTime = 0.5f;

        enemyState = EnemyState.Follow;
    }

    protected override void Update()
    {
        switch (enemyState)
        {
            case EnemyState.Follow:

                if (playerToChase != null)
                {
                    Move();
                }

                break;

            case EnemyState.Attack:

                Boo();

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

    private void Boo()
    {
        SoundManager.Instance.PlayGhostSound();

        tempCoolTime -= Time.deltaTime;

        if (tempCoolTime <= 0)
        {
            Instantiate(basicGhostProjectile, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);

            tempCoolTime = coolTime;
        }
    }

    public override void Die()
    {
        int whatToDrop = Random.Range(0, 11);

        if (whatToDrop == 0)
        {
            DropHEAL();
        }
        else
        {
            DropEXP();
        }    

        EnemyPoolManger.Instance.ReturnEnemy(this);
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
