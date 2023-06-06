using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinPickup : MonoBehaviour, ICollectable
{
    private bool _collected = false;
    private Transform _coinCollectTransform;
    [SerializeField] private Vector3 targetSize;
    [SerializeField] private float speed = 10f;
    [SerializeField] private float scalingSpeed = 3;

    private void Start()
    {
        _coinCollectTransform = GameObject.Find("CoinCollectTransform").transform;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (_collected)
        {
            transform.position = Vector3.MoveTowards(transform.position, _coinCollectTransform.position,
                Time.deltaTime * speed);

            transform.localScale = Vector3.Lerp(transform.localScale, targetSize, scalingSpeed * Time.deltaTime);

            if (transform.position == _coinCollectTransform.position)
            {
                UIManager.Instance.AddCoin();
                Destroy(gameObject);
            }
        }
    }

    public void Collect(Collider2D collider2D)
    {
        _collected = true;
    }
}