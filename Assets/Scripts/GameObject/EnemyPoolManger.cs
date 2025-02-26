using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPoolManger : MonoBehaviour
{
    public static EnemyPoolManger Instance;

    [SerializeField]
    private GameObject enemy;

    private Queue<Enemy> enemyQueue = new Queue<Enemy>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Initialize(50);
    }

    private void Initialize(int size)
    {
        for (int i = 0; i < size; i++)
        {
            enemyQueue.Enqueue(CreateNewEnemy());
        }
    }

    private Enemy CreateNewEnemy()
    {
        var newEnemy = Instantiate(enemy).GetComponent<Enemy>();

        newEnemy.gameObject.SetActive(false);

        newEnemy.transform.SetParent(transform);

        return newEnemy;
    }

    public Enemy GetEnemy()
    {
        if (Instance.enemyQueue.Count > 0)
        {
            var enemy = Instance.enemyQueue.Dequeue();

            enemy.transform.SetParent(null);

            enemy.gameObject.SetActive(true);

            return enemy;
        }
        else
        {
            var newEnemy = Instance.CreateNewEnemy();

            newEnemy.gameObject.SetActive(true);

            newEnemy.transform.SetParent(null);

            return newEnemy;
        }
    }

    public void ReturnEnemy(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);

        enemy.transform.SetParent(Instance.transform);

        Instance.enemyQueue.Enqueue(enemy);
    }
}
