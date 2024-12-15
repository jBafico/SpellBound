using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private EnemyFactory.EnemyType _enemyType;
    [SerializeField] private List<GameObject> _doors;

    private int _enemyQuantity;
    private bool _trigerred;

    private EnemyFactory _enemyFactory;

    private void Start() 
    {
        _enemyFactory = EnemyFactory.instance;
        _enemyQuantity = 0;
        _trigerred = false;
        foreach (var door in _doors)
        {
            door.SetActive(false);
        }
    }

    private void Update()
    {
        if (_trigerred)
        {
            //this will trigger only the first time the spawner is triggered
            if (_enemyQuantity == 0)
            {
                foreach (var door in _doors)
                {
                    door.SetActive(true);
                }
            }
            
            //we update the number of enemies in the room
            _enemyQuantity = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (_enemyQuantity <= 0)
            {
                _trigerred = false;
                foreach (var door in _doors)
                {
                    Destroy(door);
                }
                Destroy(this);
            }
        }
            
    }

    #endregion
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!_trigerred && other.gameObject.CompareTag("Player"))
        {
            GameObject tutorialObject = GameObject.FindWithTag("Tutorial");
            if (tutorialObject != null && tutorialObject.activeInHierarchy)
            {
                EventsManager.Instance.EventTutorialFinished();
            }
            foreach (var spawnPoint in _spawnPoints)
            {
                _enemyFactory.CreateEnemy(_enemyType, spawnPoint.transform.position);
            }

            _trigerred = true;
        }
    }
}
