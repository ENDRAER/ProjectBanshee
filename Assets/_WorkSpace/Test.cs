using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject GO;
    public GameObject C;

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GO.transform.position - transform.position), 2 * Time.deltaTime);
    }
}
