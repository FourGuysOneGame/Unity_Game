using UnityEngine;

[System.Serializable]
public class PlayerStats
{
    public Vector2 Direction { get; set; }
    public float Speed { get; set; }

    [SerializeField] private float walkSpeed = 7f;
    [SerializeField] private float runSpeed;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private int livesAmount = 3;
    public float WalkSpeed => walkSpeed;
    public float JumpForce => jumpForce;
    public int LivesAmount => livesAmount;
}