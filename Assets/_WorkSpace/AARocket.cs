using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AARocket : MonoBehaviour
{
    [SerializeField] private Rigidbody RB;
    [NonSerialized] public GameObject Pursued;
    [NonSerialized] private bool Hunting = true;

    void FixedUpdate()
    {
        if (Hunting) 
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Pursued.transform.position - transform.position), 0.4f);
        RB.AddRelativeForce(new(0, 0, 900)); 
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
