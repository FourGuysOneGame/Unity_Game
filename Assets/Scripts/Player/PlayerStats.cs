using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerStats
{
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }

    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject weapon;
    public float WalkSpeed => walkSpeed;
    public float JumpForce => jumpForce;

    public GameObject Weapon
    {
        get => weapon;
        set => weapon = value;
    }
}