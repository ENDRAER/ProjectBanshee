using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class BulletScript : MonoBehaviour
{
    [SerializeField] public Rigidbody RB;
    [SerializeField] private GameObject SpriteGO;
    [NonSerialized] public BansheeScript _bansheeCS;

    private void Start()
    {
        StartCoroutine(TimeToDestroy());
    }

    private void Update()
    {
        SpriteGO.transform.LookAt(_bansheeCS.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    IEnumerator TimeToDestroy() 
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
