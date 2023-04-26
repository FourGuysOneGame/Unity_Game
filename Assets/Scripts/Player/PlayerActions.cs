using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerActions
{
    private readonly Player _player;

    public PlayerActions(Player player)
    {
        this._player = player;
    }

    public void Move(Transform transform)
    {
        _player.Components.Rigidbody2D.velocity =
            new Vector2(_player.Stats.Direction.x * _player.Stats.Speed, _player.Components.Rigidbody2D.velocity.y);
        if (_player.Stats.Direction.x != 0)
        {
            transform.localScale = new Vector3(_player.Stats.Direction.x < 0 ? -1 : 1, 1, 1);
        }
    }

    public void Jump()
    {
        if (_player.Utilities.IsGrounded())
        {
            _player.Components.Rigidbody2D.AddForce(new Vector2(0, _player.Stats.JumpForce), ForceMode2D.Impulse);
        }
    }

    public void Shoot()
    {
        Transform firePoint = _player.References.FirePoint;
        GameObject bullet =
            Object.Instantiate(_player.References.BulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = new Vector3(_player.transform.localScale.x, 0);
        bullet.GetComponent<Bullet>().Setup(direction);
    }

    public void TakeHit()
    {
        Debug.Log("Direct hit!");
    }
}