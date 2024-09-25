using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    #region VARIABLES

    [SerializeField] private List<GameObject> _spawnPoints;
    [SerializeField] private GameObject _enemyPrefab;

    public GameObject EnemyPrefab => _enemyPrefab;

    #endregion
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (var spawnPoint in _spawnPoints)
        {
            Instantiate(EnemyPrefab, spawnPoint.GetComponent<Transform>().position, Quaternion.identity);
        }
        Destroy(this);
    }
}
