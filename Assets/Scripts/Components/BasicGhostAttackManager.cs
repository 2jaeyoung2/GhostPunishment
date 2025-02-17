using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGhostAttackManager : MonoBehaviour
{
    [SerializeField]
    protected float damage;

    void Start()
    {
        damage = 5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<IDamageable>()?.GetDamage(damage);
            
            Destroy(gameObject);
        }
    }
}
