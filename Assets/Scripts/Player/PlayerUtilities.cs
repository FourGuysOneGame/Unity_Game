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
            new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

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
        Bounds bounds = _player.Components.Collider2D.bounds;
        RaycastHit2D hit = Physics2D.BoxCast(bounds.center,
            bounds.size, 0, Vector2.down, 0.1f, _player.Components.GroundLayer);
        return hit.collider != null;
    }

    public bool IsOnLadder()
    {
        LayerMask whatIsLadder = LayerMask.GetMask("Ladder");
        RaycastHit2D isLadder = Physics2D.Raycast(_player.transform.position, Vector2.up, 1, whatIsLadder);
        
        return isLadder.collider != null;
    }
}