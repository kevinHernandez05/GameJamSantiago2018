﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawSceneLine : MonoBehaviour
{
    public Transform from;
    public Transform to;

    private void OnDrawGizmosSelected()
    {
        if (from != null && to != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(from.position, to.position);
        }
    }
}
