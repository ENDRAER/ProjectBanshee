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
        RB.AddRelativeForce(new(0,0, BansheeSpeed * (Input.GetButton("Boost")? 1.3f : 1)));
        RB.AddRelativeTorque(new(Input.GetAxis("Ver") * 5, Input.GetAxis("RHor") * 2, Input.GetAxis("Hor") * 7));
        EngineAU.pitch = 0.5f + (1f / 200f * RB.velocity.magnitude);
        Speedometer.text = ((int)RB.velocity.magnitude).ToString();
        if (Input.GetAxis("Fire") > 0.9f && ReadyToShoot)
        {
            ReadyToShoot = false;
            Shoot[IsRightGunTurn ? 0 : 1].Play();
            GameObject bulletGO = Instantiate(BulletPF, IsRightGunTurn? BulletSpawners[0].transform.position : BulletSpawners[1].transform.position, transform.rotation);
            BulletScript bulletCS = bulletGO.GetComponent<BulletScript>();
            bulletCS._bansheeCS = this;
            bulletCS.RB.velocity = RB.velocity;
            bulletCS.RB.AddRelativeForce(new(0, 0, 200),ForceMode.Impulse);
            IsRightGunTurn = !IsRightGunTurn;
            StartCoroutine(ReadyToShootCor());
        }
    }

    void Update()
    {
        FPVCamera.fieldOfView = 60 + (20f / 200f * RB.velocity.magnitude);
    }

    IEnumerator ReadyToShootCor()
    {
        yield return new WaitForSeconds(0.1f);
        ReadyToShoot = true;
    }
}
