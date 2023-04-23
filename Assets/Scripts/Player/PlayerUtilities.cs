using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;

    private List<Command> _commands = new List<Command>();

    public PlayerUtilities(Player player)
    {
        this._player = player;
        _commands.Add(new JumpCommand(_player, KeyCode.Space));
        _commands.Add(new ShootCommand(_player, KeyCode.Mouse0));
    }

    public void HandleInput()
    {
        _player.Stats.Direction =
            new Vector2(Input.GetAxisRaw("Horizontal"), _player.Components.Rigidbody2D.velocity.y);

        foreach (Command command in _commands)
        {
            if (Input.GetKeyDown(command.Key))
            {
                command.GetKeyDown();
            }

            if (Input.GetKeyUp(command.Key))
            {
                command.GetKeyUp();
            }

            if (Input.GetKey(command.Key))
            {
                command.GetKey();
            }
        }
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.BoxCast(_player.Components.Collider2D.bounds.center,
            _player.Components.Collider2D.bounds.size, 0, Vector2.down, 0.1f, _player.Components.GroundLayer);
        return hit.collider != null;
    }
}