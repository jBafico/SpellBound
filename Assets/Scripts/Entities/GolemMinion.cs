using System;
using UnityEngine;

public class GolemMinion : Enemy
{
    #region CONSTANT_PROPERTIES
    
    private string WALK_MOVEMENT_STRATEGY = "EntityWalk";
    private float moveDuration = 5f; // Duration to move (in seconds)
    private float pauseDuration = 2f; // Duration to pause (in seconds)
    
    #endregion
    
    #region PROPERTIES
    
    private EntityWalk _characterWalk;
    private IMoveable _movementLogic;
    private float timer; // Timer to track movement/pause intervals
    private bool isMoving = true; // State flag to determine if moving or pausing
    
    #endregion
    
    void Start()
    {
        AddDynamicComponent(WALK_MOVEMENT_STRATEGY);
        
        _characterWalk = GetComponent<EntityWalk>();
        _movementLogic = _characterWalk;
        
        // if no target specified, assume the player
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        
        timer = moveDuration; // Start with moving state
    }

    private void Update()
    {
        if (target == null)
            return;

        // Decrease the timer based on time elapsed since the last frame
        timer -= Time.deltaTime;

        if (isMoving)
        {
            // Move towards the target if within the movement phase
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > minDist)
            {
                _movementLogic.MoveTowards(target.position);
            }

            // Switch to pause state when the movement duration ends
            if (timer <= 0f)
            {
                isMoving = false;
                timer = pauseDuration;
            }
        }
        else
        {
            // Switch back to moving state when the pause duration ends
            if (timer <= 0f)
            {
                isMoving = true;
                timer = moveDuration;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the enemy collides with the Player
        if (collision.gameObject.CompareTag("Player"))
        {
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(Damage);
        }
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
