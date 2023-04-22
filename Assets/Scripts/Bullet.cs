using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private float speed;
    private Vector2 _direction;
    [SerializeField] private string targetTag;

    public void Setup(Vector2 direction)
    {
        this._direction = direction;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
