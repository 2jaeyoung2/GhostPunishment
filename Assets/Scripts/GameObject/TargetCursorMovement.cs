using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCursorMovement : MonoBehaviour
{
    void LateUpdate()
    {
        gameObject.transform.position = FacingTarget.info.point + new Vector3(0, 0.1f, 0);
    }
}