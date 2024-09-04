using System;
using UnityEngine;


    public class CharacterJump : MonoBehaviour, IJumpeable
    {
        
        #region IJUMPEABLE_PROPERTIES

        [SerializeField] private Rigidbody _rb;
        public Rigidbody Rb => _rb;
        
        [SerializeField] private float _jumpForce;
        public float JumpForce => _jumpForce;

        [SerializeField] private bool _isGrounded;
        public bool IsGrounded => _isGrounded;

        #endregion

        #region IJUMPEABLE_METHODS

        public void Jump()
        {
            //En el juego 2D nose si tenemos salto perse
            // Usamos raycasting para decidir si colisionamos con el piso
            _isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.5f) ? true : false;


            if (_isGrounded) {
                _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            }
        }

        #endregion

        #region UNITY_METHODS

        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        #endregion


    }
