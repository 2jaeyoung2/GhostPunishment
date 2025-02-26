using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BombDrop : MonoBehaviour
{
    [SerializeField]
    private GameObject bomb;

    [SerializeField]
    private GameObject spark;

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
        coolTime = 2;

        tempCoolTime = coolTime / 2;

        dropNumber = 10;

        ableToDrop = false;
    }

    private void Update()
    {
        tempCoolTime += Time.deltaTime;

        if (tempCoolTime >= coolTime)
        {
            ableToDrop = true;

            spark.SetActive(true);
        }
        else
        {
            ableToDrop = false;

            spark.SetActive(false);
        }
    }

    public void OnActiveBombDrop(InputAction.CallbackContext ctx)
    {
        if (ctx.phase == InputActionPhase.Performed)
        {
            if (ableToDrop == true)
            {
                StartCoroutine(Drop());

                tempCoolTime = 0;
            }
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

            tempBomb.GetComponent<Rigidbody>().AddForce(randomDir * Random.Range(0.5f, 2f), ForceMode.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }
}
