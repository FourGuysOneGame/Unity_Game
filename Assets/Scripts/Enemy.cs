using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, ICollisionHandler, IHitable
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    private Transform _target;
    [SerializeField] private float attackCooldown;
    private bool _canAttack = true;
    private float _timeSinceLastAttack;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
        Attack();
        if (transform.rotation != new Quaternion(0, 0, 0, 0))
            transform.SetPositionAndRotation(transform.position, new Quaternion(0, 0, 0, 0));
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = new Vector3(transform.localScale.x, 0);
        bullet.GetComponent<Bullet>().Setup(direction);
    }

    private void Attack()
    {
        if (!_canAttack)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        if (_timeSinceLastAttack >= attackCooldown)
        {
            _canAttack = true;
        }

        if (_canAttack && _target != null &&
            Mathf.Abs(_target.transform.position.y - transform.position.y) <= 1)
        {
            _canAttack = false;
            _timeSinceLastAttack = 0;
            Shoot();
        }
    }

    private void LookAtTarget()
    {
        if (_target != null)
        {
            Transform localTransform = transform;
            Vector3 scale = localTransform.localScale;
            float scaleAbs = Mathf.Abs(scale.x);
            scale.x = _target.transform.position.x < localTransform.position.x ? -scaleAbs : scaleAbs;
            transform.localScale = scale;
        }
    }

    public void CollisionEnter(string colliderName, GameObject other)
    {
        if (colliderName == "Damage Area" && other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Actions.TakeHit();
        }

        if (colliderName == "Sight" && other.CompareTag("Player"))
        {
            if (_target == null)
            {
                _target = other.transform;
            }
        }
    }

    public void CollisionExit(string colliderName, GameObject other)
    {
        if (colliderName == "Sight" && other.CompareTag("Player"))
        {
            _target = null;
        }
    }

    public void TakeHit()
    {
        Debug.Log("I took a hit!");
    }
}