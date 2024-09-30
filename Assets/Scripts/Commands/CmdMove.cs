using UnityEngine;

public class CmdMove : ICommand
{
    private IMoveable _moveable;
    private Vector2 _direction;
    
    public CmdMove(IMoveable moveable, Vector2 direction)
    {
        _moveable = moveable;
        _direction = direction;
    }
    
    #region ICOMMAND_METHODS

    public void Do()
    {
        _moveable.Move(_direction);
    }

    #endregion
}
