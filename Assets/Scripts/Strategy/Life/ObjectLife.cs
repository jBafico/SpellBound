using UnityEngine;


public class ObjectLife : MonoBehaviour, IDamageable
{
    #region IDAMAGEABLE_PROPERTIES

    public float MaxLife => _maxlife;
    [SerializeField] private float _maxlife = 30;
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
        if (gameObject.CompareTag("Box"))
        {
            EventsManager.Instance.EventCrateDestroyed(gameObject);
        }
        Destroy(gameObject);
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
        if(_currentLife<=0) Die();
    }

    #endregion

}