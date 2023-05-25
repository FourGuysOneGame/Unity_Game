using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    private Vector2 _direction;
    [SerializeField] private List<String> targetTags;

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
        string collidedItemTag = other.collider.tag;
        
        if (targetTags.Contains(collidedItemTag))
        {
            if (collidedItemTag == "Player")
            {
                other.gameObject.GetComponent<Player>().Actions.TakeHit();
            }
            else if (collidedItemTag == "Enemy")
            {
                other.gameObject.GetComponent<Enemy>().TakeHit();
            }
            else if (collidedItemTag == "LifeHeart")
            {
                Destroy(other.gameObject);
            }
            else 
            {
                other.gameObject.GetComponentInParent<IHitable>().TakeHit();
            }
            
        }

        Destroy(gameObject);
    }
}