using System;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region PROPERTIES

    [SerializeField] private List<GameObject> _guns;
    private IGun _currentGun;

    #endregion

    #region UNITY_METHODS

    private void Start()
    {
        GunSelection(0);
    }

    #endregion

    #region PRIVATE_METHODS

    private void GunSelection(int index)
    {
        foreach (var gun in _guns)
        {
            gun.SetActive(false);
        }
        
        _guns[index].SetActive(true);
        _currentGun = _guns[index].GetComponent<IGun>();
    }

    #endregion
    

}
