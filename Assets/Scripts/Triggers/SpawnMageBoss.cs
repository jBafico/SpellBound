using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMageBoss : SpawnEnemies
{
    [SerializeField] private List<GameObject> _tpPoints;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            foreach (var spawnPoint in _spawnPoints)
            {
                GameObject boss= Instantiate(EnemyPrefab, spawnPoint.GetComponent<Transform>().position, Quaternion.identity);
                MageBoss bossScript = boss.GetComponent<MageBoss>();
                bossScript.assignTPPoints(_tpPoints);
            }

            Destroy(this);
        }
    }
}