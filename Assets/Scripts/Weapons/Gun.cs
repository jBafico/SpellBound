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

    #region VISUAL_PROPERTIES

    private Camera _mainCam;
    private Vector3 _mousePos;
    #endregion

    #region I_GUN_METHODS

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Reload();
    }

    private void Update()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0,0,rotZ);
    }

    public virtual void Attack() => Debug.LogWarning("Implement attack Method");

    public virtual void Reload() => _currentBulletCount = _maxBulletCount;

    protected void UpdateBulletCount()
    {
        _currentBulletCount--;

        if (CurrentBulletCount <= 0) _currentBulletCount = 0;
    }
    #endregion
    
    
}
