using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem sparkEffect;

    [SerializeField]
    private ParticleSystem explosionEffect;

    [SerializeField]
    private MeshRenderer bomb;

    [SerializeField]
    private float damage;

    private void Start()
    {
        damage = 30f;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(1f);

        sparkEffect.Stop();

        explosionEffect.Play();

        bomb.enabled = false;

        var damagedEnemies = Physics.OverlapSphere(gameObject.transform.position, 3.5f);

        foreach (var a in damagedEnemies)
        {
            if (a.CompareTag("Enemy"))
            {
                a.GetComponent<IDamageable>()?.GetDamage(damage);
            }
        }

        yield return new WaitUntil(() => explosionEffect.IsAlive() == false);

        Destroy(gameObject); // TODO: 옵젝풀 할 때 Return으로 바꾸고 bomb.enabled를 true로 바꿔줘야 함.
    }
}
