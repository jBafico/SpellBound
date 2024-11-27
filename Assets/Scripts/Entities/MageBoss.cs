using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MageBoss : Boss
{
    private string CRAWL_MOVEMENT_STRATEGY = "BossCrawl";
    [SerializeField] private List<GameObject> _teleportationPoints;
    private int ticks = 2000;
    public Transform target;
    //For enemy movement towards players
    public float minDist = 1f;
    private BossCrawl _characterCrawl;
    private IMoveable _movementLogic;
    void Start()
    {
        AddDynamicComponent(CRAWL_MOVEMENT_STRATEGY);
        
        _characterCrawl = GetComponent<BossCrawl>();
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
        if (ticks == 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, _teleportationPoints.Count);
            gameObject.transform.position = _teleportationPoints[randomIndex].transform.position;
            ticks = 2000;
        }

        ticks--;
        //get the distance between the chaser and the target
        float distance = Vector2.Distance(transform.position,target.position);

        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if(distance > minDist)	
            _movementLogic.MoveTowards(target.position);
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