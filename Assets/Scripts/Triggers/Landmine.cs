
using UnityEngine;


    public class Landmine : MonoBehaviour
    {

        [SerializeField] private float _damageAmount;
        public float DamageAmount => _damageAmount;
        

        private void OnTriggerEnter(Collider collider)
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            damageable?.TakeDamage(_damageAmount);
            
            //Instanciar particula de explosion
            
            Destroy(gameObject);
        }
    }
