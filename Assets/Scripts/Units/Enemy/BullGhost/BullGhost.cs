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
    }

    protected override void Update()
    {
        Move();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);

            collision.gameObject.GetComponent<IDamageable>()?.GetDamage(damage);

            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveSpeed = 5f;
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
