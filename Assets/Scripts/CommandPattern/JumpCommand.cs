using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : Command
{
    private Player _player;
    public JumpCommand(Player player, KeyCode keyCode) : base(keyCode)
    {
        this._player = player;
    }

    public override void GetKeyDown()
    {
        _player.Actions.Jump();
    }
}
