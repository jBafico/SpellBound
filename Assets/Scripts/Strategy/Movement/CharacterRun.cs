

using UnityEngine;


    public class CharacterRun: MonoBehaviour, IMoveable
    {
        #region IMOVABLE_PROPERTIES

        public float Speed => _speed;

        [SerializeField] private float _speed = 20;
        

        #endregion
        
        #region IMOVABLE_METHODS
        public void Move(Vector2 direction)
        {
            Vector3 movement = direction;
            transform.position +=  movement * Time.deltaTime * Speed;
        }
        
        #endregion
    }
