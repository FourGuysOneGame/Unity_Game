using UnityEngine;

[System.Serializable]
public class PlayerReferences
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private LayerMask ladder;

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

    public LayerMask Ladder
    {
        get => ladder;
        set => ladder = value;
    }
}