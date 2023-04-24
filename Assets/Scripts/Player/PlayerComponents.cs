using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField] private Rigidbody2D rigidbody2D;

    [SerializeField] private Animator animator;

    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Collider2D collider2D;

    public Rigidbody2D Rigidbody2D => rigidbody2D;

    public Animator Animator { get; set; }
    public LayerMask GroundLayer => groundLayer;
    public Collider2D Collider2D => collider2D;
}