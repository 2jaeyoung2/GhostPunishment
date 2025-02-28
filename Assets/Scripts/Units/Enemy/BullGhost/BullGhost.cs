using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullGhost : Enemy
{
    protected override float EnemyHP { get => base.EnemyHP; set => base.EnemyHP = value; }

    protected override float MoveSpeed { get => base.MoveSpeed; set => base.MoveSpeed = value; }

    [SerializeField]
    protected float damage;

    [SerializeField]
    private GameObject explosionEffect;

    private GameObject tempHealgem;

    protected override void Start()
    {
        damage = 3f;

        EnemyHP = 20f;

        MoveSpeed = 0.8f;

        playerToChase = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        if (playerToChase != null)
        {
            Move();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);

            SoundManager.Instance.BullExplodeSound();

            other.GetComponent<IDamageable>()?.GetDamage(damage);

            Destroy(gameObject);
        }

    }

    protected override void Move()
    {
        if (Vector3.Distance(transform.position, playerToChase.transform.position) < 4f)
        {
            MoveSpeed = 5f;
        }

        transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime);
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
