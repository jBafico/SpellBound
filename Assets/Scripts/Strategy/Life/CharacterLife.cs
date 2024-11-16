using System;
using Unity.VisualScripting;
using UnityEngine;


    public class CharacterLife : MonoBehaviour, IDamageable
    {
        #region IDAMAGEABLE_PROPERTIES

        public float MaxLife => GetComponent<Character>().CharacterStats.MaxLife;
        public float CurrentLife => _currentLife;
        
        
        [SerializeField] private float _currentLife;
        [SerializeField] private DamageSoundEffectController _damageSoundEffect;
        #endregion

        #region UNITY_EVENTS

        private void Start()
        {
            _currentLife = MaxLife;
        }

        #endregion

        #region IDAMAGEABLE_METHODS

        public void Die()
        {
            Destroy(gameObject);
            if (gameObject.CompareTag("Player"))
            {
                EventsManager.Instance.EventGameOver(false);
            }
        }

        public void LifeRecover(float amount)
        {
            _currentLife += amount;
            if (_currentLife > MaxLife) _currentLife = MaxLife;
        }

        public void TakeDamage(float damage)
        {
            _currentLife -= damage;
            _damageSoundEffect.Play();
            if(gameObject.CompareTag("Player")) EventsManager.Instance.EventTakingDamage(5f,0.5f);
            if(_currentLife<=0) Die();
        }

        #endregion

    }
