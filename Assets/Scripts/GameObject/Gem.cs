using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Gem : MonoBehaviour
{
    private Animator hoverAnimation;

    private float experiencePoint = 1.5f;

    private float moveSpeed = 5f;

    private int playerLayer;

    private void Start()
    {
        hoverAnimation = gameObject.GetComponent<Animator>();

        playerLayer = LayerMask.GetMask("PLAYER");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.LookAt(other.transform);

            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

            if (Physics.CheckSphere(transform.position, 0.08f, playerLayer))
            {
                other.GetComponent<IExp>()?.GetExp(experiencePoint);

                GemPoolManager.Instance.ReturnGem(this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hoverAnimation.enabled = false;
        }
    }
}
