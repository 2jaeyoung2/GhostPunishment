using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject levelUP;

    [SerializeField]
    private GameObject healthPointUP;

    private void Start()
    {
        player.OnLevelChanged += LevelUP;

        player.OnGetHP += HealthPointUP;
    }

    private void LevelUP()
    {
        StartCoroutine(LevelUPEffect());
    }

    private IEnumerator LevelUPEffect()
    {
        var effect = Instantiate(levelUP, transform.position, transform.rotation);

        var particleSystem = effect.GetComponent<ParticleSystem>();

        while (particleSystem.IsAlive() == true)
        {
            effect.transform.position = gameObject.transform.position;

            yield return null;
        }

        Destroy(effect);
    }

    private void HealthPointUP()
    {
        StartCoroutine(HealthPointUPEffect());
    }

    private IEnumerator HealthPointUPEffect()
    {
        var effect = Instantiate(healthPointUP, transform.position, transform.rotation);

        var particleSystem = effect.GetComponent<ParticleSystem>();

        while (particleSystem.IsAlive() == true)
        {
            effect.transform.position = gameObject.transform.position;

            yield return null;
        }

        Destroy(effect);
    }
}
