using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] protected List<GameObject> _spawnPoints;
    [SerializeField] protected GameObject _enemyPrefab;

    public GameObject EnemyPrefab => _enemyPrefab;

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
                Instantiate(EnemyPrefab, spawnPoint.GetComponent<Transform>().position, Quaternion.identity);
            }

            Destroy(this);
        }
    }
}
