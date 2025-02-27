using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinByPhase : MonoBehaviour
{
    [SerializeField]
    private Boss boss;

    [SerializeField]
    private Material[] skinPerPhases;

    [SerializeField]
    private Renderer skinRenderer;

    private void Start()
    {
        boss.OnPhaseChanged += ChangeSkin;
    }

    private void ChangeSkin(Phase phase)
    {
        switch (phase)
        {
            case Phase.Pink:
                skinRenderer.material = skinPerPhases[0];
                break;

            case Phase.Red:
                skinRenderer.material = skinPerPhases[1];
                break;

            case Phase.Dead:
                skinRenderer.material = skinPerPhases[2];
                break;
        }
    }

    private void OnDestroy()
    {
        boss.OnPhaseChanged -= ChangeSkin;
    }
}
