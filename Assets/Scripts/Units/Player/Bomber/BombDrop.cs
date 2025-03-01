using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class BombDrop : MonoBehaviour
{
    public event Action<float, float> OnSkillUsed;

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
        coolTime = 15;

        tempCoolTime = 0;

        dropNumber = 10;

        ableToDrop = false;

        StartCoroutine(CountCoolTime());
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

                StartCoroutine(CountCoolTime());

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

            tempBomb.GetComponent<BombExplosion>().player = gameObject.GetComponent<Player>();

            tempBomb.transform.position = tempTargetPosition + new Vector3(0, 15f, 0);

            Vector3 randomDir = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;

            tempBomb.GetComponent<Rigidbody>().AddForce(randomDir * UnityEngine.Random.Range(0.5f, 2f), ForceMode.Impulse);

            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator CountCoolTime()
    {
        float countCoolTime = 0;

        while (countCoolTime <= coolTime)
        {
            OnSkillUsed?.Invoke(countCoolTime, coolTime);

            yield return null;

            countCoolTime += Time.deltaTime;
        }
    }
}
