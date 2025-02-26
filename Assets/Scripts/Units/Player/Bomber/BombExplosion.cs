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

        yield return new WaitUntil(() => explosionEffect.IsAlive() == false);

        Destroy(gameObject); // TODO: Return으로 바꾸고 bomb.enabled를 true로 바꿔줘야 함.
    }
}
