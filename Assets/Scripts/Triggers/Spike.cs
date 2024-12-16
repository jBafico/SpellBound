using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private float _damageAmount;
    public float DamageAmount => _damageAmount;

    [SerializeField] private Animator _animator;
        

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("trigger");
            IDamageable damageable = collider.GetComponent<IDamageable>();
            damageable?.TakeDamage(_damageAmount);
        }
    }
}
