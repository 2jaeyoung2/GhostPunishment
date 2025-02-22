using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    private float damage;

    private void Start()
    {
        damage = 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<IDamageable>()?.GetDamage(damage);
            Debug.Log(damage);
        }
    }
}
