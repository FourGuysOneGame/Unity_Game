using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbLadderCommand : Command
{
    private Player _player;

    public ClimbLadderCommand(Player player, KeyCode keyCode) : base(keyCode)
    {
        _player = player;
    }

    public override void GetKeyDown()
    {
        _player.Actions.ClimbLadder();
    }
}
