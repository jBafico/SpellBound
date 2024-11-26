using UnityEngine;


public class BossLife : MonoBehaviour, IDamageable
{
    #region IDAMAGEABLE_PROPERTIES

    public float MaxLife => GetComponent<Boss>().CharacterStats.MaxLife;
    public float CurrentLife => _currentLife;

    private Animator _animator => GetComponent<Boss>().Animator;
        
        
    [SerializeField] private float _currentLife;
    [SerializeField] private DamageSoundEffectController _damageSoundEffect;
    [SerializeField] private ParticleSystem _blood;
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
        if(gameObject.CompareTag("Boss"))
        {
            _animator.SetBool("isDead", true);
            GetComponent<Boss>().DeactivateGun();
        }
        EventsManager.Instance.EventBossBeat();
        if (gameObject.CompareTag("Mage Boss"))
        {
            Destroy(gameObject);
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
        _blood.Play();
        _damageSoundEffect.Play();
        if(_currentLife<=0) Die();
    }

    #endregion

}