using System;
using UnityEngine;

public class Necromancer : Enemy
{
    private float ticks = 1000;
    [SerializeField] private EnemyFactory.EnemyType _enemyType;

    private EnemyFactory _enemyFactory;
    
    void Start()
    {
        AddDynamicComponent(CRAWL_MOVEMENT_STRATEGY);
        
        _characterCrawl = GetComponent<EntityCrawl>();
        _movementLogic = _characterCrawl;
        _enemyFactory = EnemyFactory.instance;
        
        // if no target specified, assume the player
        if (target == null) {

            if (GameObject.FindWithTag("Player")!=null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
        
    }
    private void Update()
    {
        if (target == null)
            return;
        if (ticks == 0)
        {
            // Calculate the direction from the necromancer to the target
            Vector2 directionToTarget = (target.position - transform.position).normalized;

            // Calculate the spawn point in front of the necromancer
            Vector2 spawnPosition = (Vector2)transform.position + directionToTarget * 1f; // Offset of 1 unit in front

            _enemyFactory.CreateEnemy(_enemyType, spawnPosition);
            ticks = 1000;
        }
        //get the distance between the chaser and the target
        float distance = Vector2.Distance(transform.position,target.position);

        //so long as the chaser is nearer than the minimum distance, move towards it at rate speed.
        if(distance < minDist)	
            _movementLogic.MoveAway(target.position);
        ticks--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el enemigo collisiona con el Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detectar componente o estrategia de vida y sacar daño.
            IDamageable damageable= collision.gameObject.GetComponent<IDamageable>();
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
