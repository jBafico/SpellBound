using System;
using UnityEngine;

public class OrbBullet : MonoBehaviour, IBullet
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _lifetime = 15;

    [SerializeField] private Gun _owner;

    private GameObject _target;
    private Vector3 _playerPos;
    private Rigidbody2D _rb;
    [SerializeField] private float _force = 5;
    
    #endregion

    #region I_BULLET_PROPERTIES
    public float Speed => _speed;
    public float LifeTime => _lifetime;
    public Gun Owner => _owner;

    public float force => _force;
    #endregion

    #region I_BULLET_METHODS
    public void Travel(Vector2 direction)
    {
        Vector3 movement = direction;
        transform.position +=  movement * Time.deltaTime * Speed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        
        // Detectar componente o estrategia de vida y sacar daño.
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        damageable?.TakeDamage(Owner.GunStats.Damage);
        
        
        //Por utlimo lo destruimos
        Destroy(gameObject);
    }

    public void SetOwner(Gun owner)
    {
        _owner = owner;
    }

    #endregion

    #region UNITY_EVENTS

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("Player").gameObject;
        _playerPos = _target.transform.position;
        _rb = GetComponent<Rigidbody2D>();
        Vector3 direction = _playerPos - transform.position;
        Vector3 rotation = transform.position - _playerPos;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    private void Update()
    {
        if(_target == null) return;
        _playerPos = _target.transform.position;
        Vector3 direction = _playerPos - transform.position;
        Vector3 rotation = transform.position - _playerPos;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0) Destroy(gameObject);
    }
    #endregion
}