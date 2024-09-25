using Strategy;
using UnityEngine;


    public class Medkit : MonoBehaviour, IPowerUp
    {
        #region IPOWERUP_PROPERTIES

        [SerializeField] private float _healAmount;
        public float HealAmount => _healAmount;

        #endregion

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (GameObject.FindWithTag("Player") == collider.gameObject)
            {
                IDamageable damageable = collider.GetComponent<IDamageable>();
                damageable?.LifeRecover(_healAmount);

                Destroy(gameObject);
            }
        }
    }
