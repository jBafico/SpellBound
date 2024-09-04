using UnityEngine;

public interface IJumpeable 
{
    Rigidbody Rb { get; }
    float JumpForce { get; }
    bool IsGrounded { get; }

    void Jump();
}
