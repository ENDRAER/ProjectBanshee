using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class AACannon : MonoBehaviour
{
    [SerializeField] private GameObject RocketPF;
    [SerializeField] private GameObject Muzzle;
    [SerializeField] private GameObject BansheeGO;
    [NonSerialized] private bool Destroyed;


    private void Start()
    {
        StartCoroutine(RateOfFire());
    }

    private void Update()
    {
        if(!Destroyed)
            Muzzle.transform.LookAt(BansheeGO.transform);
    }

    IEnumerator RateOfFire()
    {
        yield return new WaitForSeconds(3);
        GameObject AARocketGO = Instantiate(RocketPF, Muzzle.transform.position, Muzzle.transform.rotation);
        AARocketGO.GetComponent<AARocket>().Pursued = BansheeGO;
        StartCoroutine(RateOfFire());
    }
}
