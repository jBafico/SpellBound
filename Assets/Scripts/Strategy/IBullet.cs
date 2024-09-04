using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    Gun Owner { get; }
    float Speed { get; }
    float LifeTime { get; }
    void Travel();

    void OnCollisionEnter(Collision collision);

    void SetOwner(Gun owner);
}
