using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class PlayerComponents
{
    [SerializeField] private Rigidbody2D rigidbody2D;

    public Rigidbody2D Rigidbody2D => rigidbody2D;

    [SerializeField] private Animator animator;
    
    public Animator Animator { get; set; }
}