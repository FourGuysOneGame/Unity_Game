using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    private PlayerActions _actions;

    [SerializeField] private PlayerComponents components;

    [SerializeField] private PlayerReferences references;

    [SerializeField] private PlayerStats stats;

    private PlayerUtilities _utilities;

    public PlayerActions Actions => _actions;
    public PlayerComponents Components => components;

    public PlayerReferences References => references;
    public PlayerStats Stats => stats;
    public PlayerUtilities Utilities => _utilities;


    // Start is called before the first frame update
    private void Start()
    {
        components.Animator = GetComponent<Animator>();
        _actions = new PlayerActions(this);
        _utilities = new PlayerUtilities(this);
        stats.Speed = stats.WalkSpeed;
    }

    // Update is called once per frame
    private void Update()
    {
        _utilities.HandleInput();
    }

    private void FixedUpdate()
    {
        _actions.Move(transform);
    }
}