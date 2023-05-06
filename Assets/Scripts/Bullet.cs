using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Vector2 _direction;
    [SerializeField] private string targetTag;

    public void Setup(Vector2 direction)
    {
        this._direction = direction;
    }

    private void Update()
    {
        transform.Translate(_direction * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Destroy(gameObject);
    }
}