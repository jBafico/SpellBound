using System;
using UnityEngine;

public class Necromancer : Enemy
{
    #region CONSTANT_PROPERTIES
    
    [SerializeField] private float spawnInterval = 5f; // Time between spawns
    [SerializeField] private EnemyFactory.EnemyType _enemyType;

    #endregion

    #region PROPERTIES
    
    private EnemyFactory _enemyFactory;

    private float spawnTimer; // Timer for spawning enemies

    #endregion

    void Start()
    {
        AddDynamicComponent(CRAWL_MOVEMENT_STRATEGY);

        _characterCrawl = GetComponent<EntityCrawl>();
        _movementLogic = _characterCrawl;
        _enemyFactory = EnemyFactory.instance;

        // If no target specified, assume the player
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }

        spawnTimer = spawnInterval; 
    }

    private void Update()
    {
        if (target == null)
            return;

        
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance < minDist)
        {
            _movementLogic.MoveAway(target.position);
        }

        // Spawning logic
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnMinion();
            spawnTimer = spawnInterval;
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

    private void SpawnMinion()
    {
        Vector2 directionToTarget = (target.position - transform.position).normalized;
        
        Vector2 spawnPosition = (Vector2)transform.position + directionToTarget * 1f; 

        _enemyFactory.CreateEnemy(_enemyType, spawnPosition);
    }

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
