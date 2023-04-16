using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce = 20f;

    private float dirX = 0f;
    bool facingRight = true;
    private static float weaponPosition = 1.6f;

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.right * fireForce, ForceMode2D.Impulse);
    }

    public void Update()
    {
        dirX = Input.GetAxis("Horizontal");

        if (dirX > 0f && !facingRight)
        {
            Flip();
        }

        // Moving to the left
        else if (dirX < 0f && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentPosition = transform.position;
        Quaternion currentFirePoint = firePoint.rotation;
        if (facingRight)
        {
            currentPosition.x -= weaponPosition;
            currentFirePoint.y = 180;
        }
        else
        {
            currentPosition.x += weaponPosition;
            currentFirePoint.y = 0;
        }
        transform.position = currentPosition;
        firePoint.rotation = currentFirePoint;

        facingRight = !facingRight;
    }

}
