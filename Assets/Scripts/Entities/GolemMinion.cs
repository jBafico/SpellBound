using System;
using UnityEngine;

public class GolemMinion : Enemy
{
    #region CONSTANT_PROPERTIES
    
    private string WALK_MOVEMENT_STRATEGY = "EntityWalk";
    [SerializeField] private float moveDuration = 5f; 
    [SerializeField] private float pauseDuration = 2f; 
    
    #endregion
    
    #region PROPERTIES
    
    private EntityWalk _characterWalk;
    private float timer; 
    private bool isMoving = true; 
    
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
        
        timer = moveDuration; 
    }

    private void Update()
    {
        if (target == null)
            return;

        
        timer -= Time.deltaTime;

        if (isMoving)
        {
            
            float distance = Vector2.Distance(transform.position, target.position);

            if (distance > minDist)
            {
                _movementLogic.MoveTowards(target.position);
            }

            
            if (timer <= 0f)
            {
                isMoving = false;
                timer = pauseDuration;
            }
        }
        else
        {
            
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
