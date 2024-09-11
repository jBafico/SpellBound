using System;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    #region CONSTANT_PROPERTIES

    private string RUN_MOVEMENT_STRATEGY = "CharacterRun";
    private string WALK_MOVEMENT_STRATEGY = "CharacterWalk";
    #endregion

    #region PROPERTIES

    private CharacterWalk _characterWalk;
    private CharacterRun _characterRun;
    private IMoveable _movementLogic;
    private CharacterJump _characterJump;

    #endregion

    [SerializeField] private List<GameObject> _guns;
    private IGun _currentGun;

    // BINDING ATTACK KEYS
    [SerializeField] private KeyCode _shoot = KeyCode.Mouse0;
    [SerializeField] private KeyCode _reload = KeyCode.R;
    
    // BINDING WEAPON KEYS
    [SerializeField] private KeyCode _selectGun1 = KeyCode.Alpha1;
    [SerializeField] private KeyCode _selectGun2 = KeyCode.Alpha2;
    
    // BINDING MOVEMENT KEYS
    [SerializeField] private KeyCode _moveForward = KeyCode.W;
    [SerializeField] private KeyCode _moveBack = KeyCode.S;
    [SerializeField] private KeyCode _moveLeft = KeyCode.A;
    [SerializeField] private KeyCode _moveRight = KeyCode.D;
    [SerializeField] private KeyCode _walkRun = KeyCode.LeftShift;

    void Start()
    {
        AddDynamicComponent(WALK_MOVEMENT_STRATEGY);
        AddDynamicComponent(RUN_MOVEMENT_STRATEGY);

        _characterWalk = GetComponent<CharacterWalk>();
        _characterRun = GetComponent<CharacterRun>();

        _movementLogic = _characterWalk;

        _characterJump = GetComponent<CharacterJump>();

        //TODO Decidir que arma iniciar
    }

    // Update is called once per frame
    void Update()
    {
        /* Movimento */
        if (Input.GetKey(_moveForward)) _movementLogic.Move(transform.up);
        if (Input.GetKey(_moveBack)) _movementLogic.Move(-transform.up);
        if (Input.GetKey(_moveRight)) _movementLogic.Move(transform.right);
        if (Input.GetKey(_moveLeft)) _movementLogic.Move(-transform.right);
        
        /* Correr/Caminar */
        if (Input.GetKeyDown(_walkRun)) _movementLogic= _characterRun;
        if (Input.GetKeyUp(_walkRun)) _movementLogic= _characterWalk;
        
        
        /* Armas */
        if (Input.GetKeyDown(_shoot)) _currentGun.Attack();
        if (Input.GetKeyDown(_reload)) _currentGun.Reload();
        
        /* Selección de arma */
        if (Input.GetKeyDown(_selectGun1)) GunSelection(0);
        if (Input.GetKeyDown(_selectGun2)) GunSelection(1);
        
    }

    #region PRIVATE_METHODS

    private void AddDynamicComponent(string name)
    {
        Type newComponent = Type.GetType($"{name}");

        if (newComponent != null)
        {
            Debug.LogWarning($"Component '{name}' added!");
            gameObject.AddComponent(newComponent);
        }
        else
        {
            Debug.LogWarning($"Component '{name}' not found!");
        }
    }

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
