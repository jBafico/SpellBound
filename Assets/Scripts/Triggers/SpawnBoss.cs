using System;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    [SerializeField] protected GameObject _spawnPoint;
    [SerializeField] private GameObject _bossPrefab;
    
    public GameObject BossPrefab => _bossPrefab;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(BossPrefab, _spawnPoint.GetComponent<Transform>().position, Quaternion.identity);
            Destroy(this);
        }
    }
}