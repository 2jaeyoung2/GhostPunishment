using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GemManager : MonoBehaviour
{
    private Animator hoverAnimation;

    private float experiencePoint = 1.5f;

    private float moveSpeed = 3.5f;

    private void Start()
    {
        hoverAnimation = gameObject.GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.LookAt(other.transform);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hoverAnimation.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<IScoreable>()?.GetExp(experiencePoint);

            Destroy(gameObject);
        }

    }
}
