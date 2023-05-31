using UnityEngine;

public class JumpCommand : Command
{
    private Player _player;
    public JumpCommand(Player player, KeyCode keyCode) : base(keyCode)
    {
        _player = player;
    }

    public override void GetKeyDown()
    {
        _player.Actions.Jump();
    }
}
