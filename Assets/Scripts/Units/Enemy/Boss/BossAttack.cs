using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    private Boss boss;

    [SerializeField]
    private GameObject lightningSpot;

    private GameObject tempSpot;

    [SerializeField]
    private GameObject lightningAttack;

    private GameObject tempAttack;

    private bool OnAttack;

    void Start()
    {
        OnAttack = false;

        boss.OnStateChanged += AttackPlayer;
    }

    private void AttackPlayer(EnemyState state)
    {
        if (state == EnemyState.Attack && OnAttack == false) // 공격 state이고 공격중이지 않으면
        {
            OnAttack = true;

            int attackType = Random.Range(0, 1); // 패턴이 여러개면 숫자 늘리면 됨

            if (attackType == 0) // 0이면 번개공격
            {
                if (player != null)
                {
                    SoundManager.Instance.PlayGrowlingSound();

                    StartCoroutine(LightningAttack());
                }
            }
        }
    }

    IEnumerator LightningAttack()
    {
        for (int i = 0; i < 3; i++) // 세 번 내려침
        {
            tempSpot = Instantiate(lightningSpot, player.transform.position, player.transform.rotation);

            float elapsedTime = 0;

            while (elapsedTime < Random.Range(1f, 2.5f))
            {
                elapsedTime += Time.deltaTime;

                tempSpot.transform.position = player.transform.position;

                yield return null;
            }

            yield return new WaitForSeconds(0.3f);

            SoundManager.Instance.PlayLightningSound();

            tempAttack = Instantiate(lightningAttack, tempSpot.transform.position, tempSpot.transform.rotation);

            yield return new WaitForSeconds(1f);

            Destroy(tempSpot);

            Destroy(tempAttack);

            yield return new WaitForSeconds(1f);
        }

        OnAttack = false;
    }
}
