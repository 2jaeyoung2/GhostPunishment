using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Heal : MonoBehaviour
{
    private Animator hoverAnimation;

    private float healAmount = 3.5f;

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
                other.GetComponent<IHeal>()?.GetHealth(healAmount);

                Destroy(gameObject);
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
