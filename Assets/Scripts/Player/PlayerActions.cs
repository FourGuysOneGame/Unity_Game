using UnityEngine;

public class PlayerActions : IHitable
{
    private readonly Player _player;

    public PlayerActions(Player player)
    {
        _player = player;
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

    public void ClimbLadder()
    {
        if (_player.Utilities.IsOnLadder())
        {
            float moveVertical = _player.Stats.Direction.y;

            _player.Components.Rigidbody2D.velocity =
                new Vector2(_player.Components.Rigidbody2D.velocity.x, moveVertical * _player.Stats.WalkSpeed);

            _player.Components.Rigidbody2D.gravityScale = 0;
        }
        else
        {
            Vector2 velocity = _player.Components.Rigidbody2D.velocity;
            velocity = new Vector2(velocity.x, velocity.y);
            _player.Components.Rigidbody2D.velocity = velocity;

            _player.Components.Rigidbody2D.gravityScale = 3;
        }
    }

    public void TakeHit()
    {
        UIManager.Instance.RemoveLife(1);
    }

    public void Heal()
    {
        UIManager.Instance.AddLife(1);
    }

    public void Collide(Collider2D collider)
    {
        if (collider.CompareTag("Collectable"))
        {
            collider.GetComponent<ICollectable>().Collect(_player.GetComponent<Collider2D>());
        }
    }
}