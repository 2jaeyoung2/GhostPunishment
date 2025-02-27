using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Transform placeToSpawnEnemy;

    private int numberToSpawn;

    private float coolTimeToSpawn;

    private float tempCoolTime;

    private void Start()
    {
        numberToSpawn = 3;

        coolTimeToSpawn = 3f;

        tempCoolTime = 1.5f;

        timer.IsTimeEnd += StopSpwaning;
    }

    void Update()
    {
        tempCoolTime -= Time.deltaTime;

        if (tempCoolTime <= 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(-180f, 180f), 0));

            for (int i = 0; i < numberToSpawn; i++)
            {
                var enemy = EnemyPoolManger.Instance.GetEnemy();

                enemy.transform.position = placeToSpawnEnemy.position + new Vector3(Random.Range(-5f, 5f), 0, 0);
            }

            tempCoolTime = coolTimeToSpawn;
        }
    }

    private void StopSpwaning()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        timer.IsTimeEnd -= StopSpwaning;
    }
}
