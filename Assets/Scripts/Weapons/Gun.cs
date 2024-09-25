using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    #region GUN_PROPERTIES
    private int _damage = 10;
    private int _maxBulletCount = 10;
    [SerializeField] private int _currentBulletCount;
    [SerializeField] private GameObject _bulletPrefab;
    
    #endregion

    #region I_GUN_PROPERTIES
    public int Damage => _damage;
    public int MaxBulletCount => _maxBulletCount;

    public int CurrentBulletCount => _currentBulletCount;
    public GameObject BulletPrefab => _bulletPrefab;
    #endregion

    #region I_GUN_METHODS

    private void Start()
    {
        Reload();
    }

    public virtual void Attack(Vector3 mousePos) => Debug.LogWarning("Implement attack Method");

    public virtual void Reload() => _currentBulletCount = _maxBulletCount;

    protected void UpdateBulletCount()
    {
        _currentBulletCount--;

        if (CurrentBulletCount <= 0) _currentBulletCount = 0;
    }
    #endregion
    
    
}
