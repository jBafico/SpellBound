using System;
using UnityEngine;

public class GolemMinion : Enemy
{
    #region CONSTANT_PROPERTIES
    
    private string WALK_MOVEMENT_STRATEGY = "EntityWalk";
    

    private float ticks = 200;
    #endregion
    
    #region PROPERTIES
    
    private EntityWalk _characterWalk;
    private IMoveable _movementLogic;
    
    #endregion
    
    void Start()
    {
        AddDynamicComponent(WALK_MOVEMENT_STRATEGY);
        
        _characterWalk = GetComponent<EntityWalk>();
        _movementLogic = _characterWalk;
        
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
        if (ticks > 0)
        {
            //get the distance between the chaser and the target
            float distance = Vector2.Distance(transform.position,target.position);

            //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
            if(distance > minDist)	
                _movementLogic.MoveTowards(target.position);

            ticks--;
        }else if (ticks == -100)
        {
            ticks = 200;
        }
        else
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
