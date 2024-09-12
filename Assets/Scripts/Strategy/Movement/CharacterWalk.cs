using TMPro.EditorUtilities;
using UnityEngine;


    public class CharacterWalk : MonoBehaviour, IMoveable
    {
        #region IMOVABLE_PROPERTIES

        public float Speed => _speed;

        [SerializeField] private float _speed = 10;
        

        #endregion
        
        #region IMOVABLE_METHODS
        public void Move(Vector3 direction)
        {
            transform.position += direction * Time.deltaTime * Speed;
        }
        
        //activar animacion de caminar
        //activar sonidos de pasos de caminar
        
        #endregion
    }
