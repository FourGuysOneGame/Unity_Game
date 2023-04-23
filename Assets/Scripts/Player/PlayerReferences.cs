using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerReferences
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    public GameObject BulletPrefab
    {
        get => bulletPrefab;
        set => bulletPrefab = value;
    }

    public Transform FirePoint
    {
        get => firePoint;
        set => firePoint = value;
    }

}