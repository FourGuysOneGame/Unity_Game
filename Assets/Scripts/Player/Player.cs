using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerActions _actions;

    [SerializeField] private PlayerComponents components;

    [SerializeField] private PlayerReferences references;

    [SerializeField] private PlayerStats stats;

    private PlayerUtilities _utilities;
    
    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource shootSoundEffect;
    [SerializeField] private AudioSource takeHitSoundEffect;
    [SerializeField] private AudioSource healSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;

    public PlayerActions Actions => _actions;
    public PlayerComponents Components => components;

    public PlayerReferences References => references;
    public PlayerStats Stats => stats;
    public PlayerUtilities Utilities => _utilities;

    public AudioSource JumpSoundEffect => jumpSoundEffect;
    public AudioSource ShootSoundEffect => shootSoundEffect;
    public AudioSource TakeHitSoundEffect => takeHitSoundEffect;
    public AudioSource HealSoundEffect => healSoundEffect;
    public AudioSource CollectSoundEffect => collectSoundEffect;


    // Start is called before the first frame update
    private void Start()
    {
        components.Animator = GetComponent<Animator>();
        _actions = new PlayerActions(this);
        _utilities = new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;

        UIManager.Instance.AddLifeContainer(stats.LivesAmount);
    }

    // Update is called once per frame
    private void Update()
    {
        _utilities.HandleInput();
    }

    private void FixedUpdate()
    {
        _actions.Move(transform);
        _actions.ClimbLadder();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _actions.Collide(other);
    }
}