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

    // Movement Strategies
    private CharacterWalk _characterWalk;
    private CharacterRun _characterRun;
    
    // Commands
    private CmdMove _cmdMoveUp;
    private CmdMove _cmdMoveDown;
    private CmdMove _cmdMoveRight;
    private CmdMove _cmdMoveLeft;
    
    [SerializeField] private List<GameObject> _guns;
    private IGun _currentGun;

    #endregion

    

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
        
        UpdateMovementCommand(_characterWalk);
        
        GunSelection(0);
    }

    // Update is called once per frame
    void Update()
    {
        /* Movimento 
        if (Input.GetKey(_moveForward)) _movementLogic.Move(Vector2.up);
        if (Input.GetKey(_moveBack)) _movementLogic.Move(-Vector2.up);
        if (Input.GetKey(_moveRight)) _movementLogic.Move(Vector2.right);
        if (Input.GetKey(_moveLeft)) _movementLogic.Move(-Vector2.right);
        */
        
        if (Input.GetKey(_moveForward)) _cmdMoveUp.Do();
        if (Input.GetKey(_moveBack)) _cmdMoveDown.Do();
        if (Input.GetKey(_moveRight)) _cmdMoveRight.Do();
        if (Input.GetKey(_moveLeft)) _cmdMoveLeft.Do();
        
        /* Correr/Caminar */
        if (Input.GetKeyDown(_walkRun)) UpdateMovementCommand(_characterRun);;
        if (Input.GetKeyUp(_walkRun)) UpdateMovementCommand(_characterWalk);;
        
        
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

    private void UpdateMovementCommand(IMoveable moveable)
    {
          _cmdMoveUp = new CmdMove(moveable, Vector2.up);
          _cmdMoveDown = new CmdMove(moveable, -Vector2.up);
          _cmdMoveRight = new CmdMove(moveable, Vector2.right);
          _cmdMoveLeft = new CmdMove(moveable, -Vector2.right);
    }
    

    #endregion
}
