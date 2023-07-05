using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AARocket : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [NonSerialized] private bool Hunting;

    void FixedUpdate()
    {
        if (Hunting)
            RB.AddRelativeForce(new(0, 0, 0));
    }
}
