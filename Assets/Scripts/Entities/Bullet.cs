using System;
using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _lifetime = 2;

    [SerializeField] private Gun _owner;

    private Vector3 _mousePos;
    private Camera _mainCam;
    private Rigidbody2D _rb;
    private float _force = 5;
    
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
        //Si la bala no collisiona con el Player
        if (!collision.gameObject.CompareTag("Player"))
        {
            // Detectar componente o estrategia de vida y sacar daño.
            IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
            damageable?.TakeDamage(Owner.GunStats.Damage);
        }

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

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        _rb = GetComponent<Rigidbody2D>();
        Vector3 direction = _mousePos - transform.position;
        Vector3 rotation = transform.position - _mousePos;
        _rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }

    private void Update()
    {
        
        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0) Destroy(gameObject);
    }
    #endregion
}