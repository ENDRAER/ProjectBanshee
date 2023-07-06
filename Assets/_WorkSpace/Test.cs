using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Rigidbody RB;
    public GameObject GO;

    void FixedUpdate()
    {
        RB.AddRelativeTorque(Quaternion.FromToRotation(GO.transform.position, transform.position).eulerAngles);
    }
}
