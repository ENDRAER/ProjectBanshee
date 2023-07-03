using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class BansheeScript : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] TextMeshProUGUI Speedometer;
    [SerializeField] float BansheeSpeedScale = 5;
    [NonSerialized] float RotationSpeedScale = 10;


    void FixedUpdate()
    {
        rb.AddRelativeForce(new(0,0,1 * BansheeSpeedScale));
        rb.AddRelativeTorque(new(Input.GetAxis("Ver") * RotationSpeedScale, (Input.GetAxis("RHor") / 4) * RotationSpeedScale, Input.GetAxis("Hor") * RotationSpeedScale));
        Speedometer.text = rb.velocity.magnitude.ToString();
    }
}
