using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region CONSTANT_PROPERTIES
    
    private string WALK_MOVEMENT_STRATEGY = "CharacterWalk";
    #endregion
    
    #region PROPERTIES

    private CharacterWalk _characterWalk;
    private IMoveable _movementLogic;
    
    #endregion
    
    void Start()
    {
        AddDynamicComponent(WALK_MOVEMENT_STRATEGY);
        
        _characterWalk = GetComponent<CharacterWalk>();
        _movementLogic = _characterWalk;
    }

    #region PRIVATE_METHODS

    private void AddDynamicComponent(string name)
    {
        Type newComponent = Type.GetType($"{name}");

        if (newComponent != null)
        {
            Debug.LogWarning($"Component '{name}' added!");
            gameObject.AddComponent(newComponent);
        }
        else
        {
            Debug.LogWarning($"Component '{name}' not found!");
        }
    }

    #endregion
}
