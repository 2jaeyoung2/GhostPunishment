using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    void Start()
    {      
        coolTime = 5f;

        tempCoolTime = coolTime / 2;

        dropNumber = 5;

        ableToDrop = false;
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
    }

    public void OnActiveBombDrop(InputAction.CallbackContext ctx)
    {
        if (ableToDrop == true)
        {
            StartCoroutine(Drop());

            tempCoolTime = 0;
        }
    }

    IEnumerator Drop()
    {
        var tempTargetPosition = target.position;

        for (int i = 0; i < dropNumber; i++)
        {
            var tempBomb = Instantiate(bomb);

            tempBomb.transform.position = tempTargetPosition + new Vector3(0, 15f, 0);

            Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

            tempBomb.GetComponent<Rigidbody>().AddForce(randomDir * 1f, ForceMode.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
