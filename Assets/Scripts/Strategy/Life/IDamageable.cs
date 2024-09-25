
    using UnityEngine;

    public interface IDamageable 
    {
        float MaxLife { get; }
        float CurrentLife { get; }

        void Die();

        void LifeRecover(float amount);

        void TakeDamage(float damage);
    }
