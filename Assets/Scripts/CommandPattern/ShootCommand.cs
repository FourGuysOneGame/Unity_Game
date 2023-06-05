using UnityEngine;

public class ShootCommand : Command
{
    private Player _player;

    public ShootCommand(Player player, KeyCode keyCode) : base(keyCode)
    {
        _player = player;
    }

    public override void GetKeyDown()
    {
        _player.Actions.Shoot();
    }
}
