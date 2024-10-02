
using UnityEngine;


    public class Lava : MonoBehaviour
    {

        [SerializeField] private float _damageAmount;
        public float DamageAmount => _damageAmount;
        

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Player"))
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();
                damageable?.TakeDamage(_damageAmount);
            }
        }
    }
