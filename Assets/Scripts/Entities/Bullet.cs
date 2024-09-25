using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private float _speed = 40;
    [SerializeField] private float _lifetime = 2;

    [SerializeField] private Gun _owner;
    #endregion

    #region I_BULLET_PROPERTIES
    public float Speed => _speed;
    public float LifeTime => _lifetime;
    public Gun Owner => _owner;
    #endregion

    #region I_BULLET_METHODS
    public void Travel() => transform.position += transform.forward * Time.deltaTime * Speed;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        // Detectar componente o estrategia de vida y sacar daño.
        IDamageable damageable= collision.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(Owner.Damage);
        
        //Tambien le podemos agregar a varios tipos de daño
        
        //Por utlimo lo destruimos
        Destroy(gameObject);
    }

    public void SetOwner(Gun owner)
    {
        _owner = owner;
    }

    #endregion

    #region UNITY_EVENTS
    private void Start() { }

    private void Update()
    {
        Travel();

        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0) Destroy(gameObject);
    }
    #endregion
}