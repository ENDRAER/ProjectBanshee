using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vihicle : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float Speed;
    [SerializeField] private float Health;


    private void FixedUpdate()
    {
        RB.AddRelativeForce(new(0, 0, Speed));
    }
}
