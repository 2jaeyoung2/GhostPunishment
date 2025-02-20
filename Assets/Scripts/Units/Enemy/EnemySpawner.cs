using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform placeToSpawnEnemy;

    [SerializeField]
    private GameObject[] enemy;

    private int numberToSpawn;

    private float coolTimeToSpawn;

    private float tempCoolTime;

    private void Start()
    {
        numberToSpawn = 3;

        coolTimeToSpawn = 3f;

        tempCoolTime = 1.5f;
    }

    void Update()
    {
        tempCoolTime -= Time.deltaTime;

        if (tempCoolTime <= 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, Random.Range(-180f, 180f), 0));

            if (enemy.Length > 0 && placeToSpawnEnemy != null)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(enemy[0], placeToSpawnEnemy.position + new Vector3(Random.Range(-20f, 20f), 0, 0), transform.rotation);
                }
            }

            tempCoolTime = coolTimeToSpawn;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }
}
