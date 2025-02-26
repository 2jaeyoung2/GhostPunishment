using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private Transform target;

    [SerializeField]
    private float coolTime;

    private float tempCoolTime;

    [SerializeField]
    private int dropNumber;

    private bool ableToDrop;

    private int floorLayer;

    private Rigidbody rb;

    void Start()
    {      
        coolTime = 5f;

        tempCoolTime = coolTime / 2;

        dropNumber = 5;

        ableToDrop = false;

        floorLayer = LayerMask.GetMask("FLOOR");

        rb = bomb.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        tempCoolTime += Time.deltaTime;

        if (tempCoolTime >= coolTime)
        {
            ableToDrop = true;
        }
        else
        {
            ableToDrop = false;
        }

        if (ableToDrop == true && Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Drop());

            tempCoolTime = 0;
        }
    }

    IEnumerator Drop()
    {
        for (int i = 0; i < dropNumber; i++)
        {
            var tempBomb = Instantiate(bomb);

            tempBomb.transform.position = target.position + new Vector3(0, 15f, 0);

            Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

            rb.AddForce(randomDir * 2f, ForceMode.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
