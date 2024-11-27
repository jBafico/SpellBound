using System;
using System.Collections.Generic;
using UnityEngine;

public class MageBoss : Boss
{
    private string CRAWL_MOVEMENT_STRATEGY = "BossCrawl";
    [SerializeField] private List<GameObject> _teleportationPoints;
    [SerializeField] private float teleportInterval = 5f; 
    
    public Transform target;
    public float minDist = 1f;
    private BossCrawl _characterCrawl;
    private IMoveable _movementLogic;
    
    private float teleportTimer; 

    void Start()
    {
        AddDynamicComponent(CRAWL_MOVEMENT_STRATEGY);

        _characterCrawl = GetComponent<BossCrawl>();
        _movementLogic = _characterCrawl;

        // if no target specified, assume the player
        if (target == null)
        {
            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }

        teleportTimer = teleportInterval; 
    }

    private void Update()
    {
        if (target == null)
            return;

        
        teleportTimer -= Time.deltaTime;
        if (teleportTimer <= 0f)
        {
            Teleport();
            teleportTimer = teleportInterval; 
        }
        
        float distance = Vector2.Distance(transform.position, target.position);
        if (distance > minDist)
        {
            _movementLogic.MoveTowards(target.position);
        }
    }

    private void Teleport()
    {
        if (_teleportationPoints.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, _teleportationPoints.Count);
            transform.position = _teleportationPoints[randomIndex].transform.position;
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

    public void assignTPPoints(List<GameObject> tpPoints)
    {
        _teleportationPoints = tpPoints;
    }

    #endregion
}
