using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMageBoss : SpawnBoss
{
    [SerializeField] private List<GameObject> _tpPoints;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject boss= Instantiate(BossPrefab, _spawnPoint.GetComponent<Transform>().position, Quaternion.identity);
            MageBoss bossScript = boss.GetComponent<MageBoss>();
            bossScript.assignTPPoints(_tpPoints);
            Destroy(this);
        }
    }
}