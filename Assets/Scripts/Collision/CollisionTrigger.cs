using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    private ICollisionHandler _handler;

    private void Start()
    {
        _handler = GetComponentInParent<ICollisionHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _handler.CollisionEnter(gameObject.name, other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _handler.CollisionExit(gameObject.name, other.gameObject);
    }
}