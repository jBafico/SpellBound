using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region CONSTANT_PROPERTIES
    
    private string CRAWL_MOVEMENT_STRATEGY = "CharacterCrawl";
    
    //For enemy movement towards players
    public float minDist = 1f;
    public Transform target;
    
    public float Damage => _damage;
    [SerializeField] private float _damage = 20;
    #endregion
    
    #region PROPERTIES

    private CharacterCrawl _characterCrawl;
    private IMoveable _movementLogic;
    
    #endregion
    
    void Start()
    {
        AddDynamicComponent(CRAWL_MOVEMENT_STRATEGY);
        
        _characterCrawl = GetComponent<CharacterCrawl>();
        _movementLogic = _characterCrawl;
        
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
        
        //get the distance between the chaser and the target
        float distance = Vector2.Distance(transform.position,target.position);

        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if(distance > minDist)	
            _movementLogic.MoveTowards(target.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si el enemigo collisiona con el Player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Detectar componente o estrategia de vida y sacar daño.
            IDamageable damageable= collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(_damage);
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
