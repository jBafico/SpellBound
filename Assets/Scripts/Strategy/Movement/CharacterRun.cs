

using UnityEngine;


    public class CharacterRun: MonoBehaviour, IMoveable
    {
        #region IMOVABLE_PROPERTIES

        public float Speed => GetComponent<Character>().CharacterStats.MoveSpeed * 2;

        private Animator _animator => GetComponent<Character>().Animator;

        #endregion
        
        #region IMOVABLE_METHODS
        public void Move(Vector2 direction)
        {
            _animator.SetFloat("Speed", 0.6f);
            Vector3 movement = direction;
            transform.position +=  movement * Time.deltaTime * Speed;
        }
        
        public void MoveTowards(Vector2 target)
        {
            transform.position = Vector2.MoveTowards(transform.position,target, Speed*Time.deltaTime);
        }
        
        #endregion
    }
