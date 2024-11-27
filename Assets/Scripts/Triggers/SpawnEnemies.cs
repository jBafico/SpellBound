using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private EnemyFactory.EnemyType _enemyType;

    private EnemyFactory _enemyFactory;

    private void Start() 
    {
        _enemyFactory = EnemyFactory.instance;
    }

    #endregion
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
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

            Destroy(this);
        }
    }
}
