using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    #region PROPERTIES
    
    private IGun _currentGun;

    [SerializeField] private GameObject _bossGun;
    
    public CharacterStats CharacterStats => _characterStats;
    [SerializeField] private CharacterStats _characterStats;

    public Animator Animator => _animator;
    [SerializeField] private Animator _animator;

    #endregion
    

    #region PRIVATE_METHODS
    

    public void DeactivateGun()
    {
        Destroy(_bossGun);
    }

    #endregion
    

}
