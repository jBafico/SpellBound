using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveable
{
    float Speed { get; }
    
    void Move(Vector2 direction);

    public void MoveTowards(Vector2 target);

    public void MoveAway(Vector2 target);
}
