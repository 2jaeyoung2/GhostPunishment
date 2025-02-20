using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemy;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) //TODO: 임시 스폰
        {
            Instantiate(enemy[0], transform.position + new Vector3(Random.Range(-20f, 20f), 0, 0), transform.rotation);
        }
    }
}
