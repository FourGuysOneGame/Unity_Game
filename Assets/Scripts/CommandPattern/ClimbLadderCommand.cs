using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadderCommand : Command
{
    private Player _player;

    public ClimbLadderCommand(Player player, KeyCode keyCode) : base(keyCode)
    {
        this._player = player;
    }

    public override void GetKeyDown()
    {
        _player.Actions.ClimbLadder();
    }
}
