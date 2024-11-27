using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour, IGun
{
    public GunStats GunStats => _gunStats;
    [SerializeField] private GunStats _gunStats;
    
    #region GUN_PROPERTIES
    [SerializeField] private int _currentBulletCount;
    
    protected int _currentTicks;
    [SerializeField] protected int ticks = 200;
    
    #endregion

    #region I_GUN_PROPERTIES
    public int Damage => GunStats.Damage;
    public int MaxBulletCount => GunStats.MaxBullets;

    public int CurrentBulletCount => _currentBulletCount;
    public GameObject BulletPrefab => GunStats.BulletPrefab;
    #endregion

    #region VISUAL_PROPERTIES

    public Camera _mainCam;
    public Vector3 _mousePos;
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

    public virtual void Reload() => _currentBulletCount = MaxBulletCount;

    protected void UpdateBulletCount()
    {
        _currentBulletCount--;

        if (CurrentBulletCount <= 0) _currentBulletCount = 0;
    }
    #endregion

    
    
}
