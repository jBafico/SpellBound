using System;
using Unity.VisualScripting;
using UnityEngine;


    public class CharacterLife : MonoBehaviour, IDamageable
    {
        #region IDAMAGEABLE_PROPERTIES

        public float MaxLife => _maxLife;
        public float CurrentLife => _currentLife;
        
        [SerializeField] private float _maxLife = 100;
        [SerializeField] private float _currentLife;
        [SerializeField] private DamageSoundEffectController _damageSoundEffect;
        #endregion

        #region UNITY_EVENTS

        private void Start()
        {
            _currentLife = _maxLife;
        }

        #endregion

        #region IDAMAGEABLE_METHODS

        public void Die()
        {
            Destroy(gameObject);
            if (GameObject.FindGameObjectWithTag("Player") == gameObject)
            {
                EventsManager.Instance.EventGameOver(false);
            }
            else if(GameObject.FindGameObjectWithTag("Boss")== gameObject)
            {
                EventsManager.Instance.EventBossBeat();
            }
        }

        public void LifeRecover(float amount)
        {
            _currentLife += amount;
            if (_currentLife > _maxLife) _currentLife = _maxLife;
        }

        public void TakeDamage(float damage)
        {
            _currentLife -= damage;
            _damageSoundEffect.PlayOnShot();
            if(_currentLife<=0) Die();
        }

        #endregion

    }
