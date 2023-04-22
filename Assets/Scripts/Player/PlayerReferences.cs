using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerReferences
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _fireForce = 20f;

    public GameObject BulletPrefab
    {
        get => _bulletPrefab;
        set => _bulletPrefab = value;
    }

    public Transform FirePoint
    {
        get => _firePoint;
        set => _firePoint = value;
    }

    public float FireForce
    {
        get => _fireForce;
        set => _fireForce = value;
    }
}