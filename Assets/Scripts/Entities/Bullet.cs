using UnityEngine;

public class Bullet : MonoBehaviour, IBullet
{
    #region PRIVATE_PROPERTIES
    [SerializeField] private float _speed = 40;
    [SerializeField] private float _lifetime = 2;

    [SerializeField] private Gun _owner;

    private Vector3 _mousePos;
    private Camera _mainCam;
    #endregion

    #region I_BULLET_PROPERTIES
    public float Speed => _speed;
    public float LifeTime => _lifetime;
    public Gun Owner => _owner;
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

    private void Start()
    {
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        
    }

    private void Update()
    {
        Vector3 direction = _mousePos - transform.position;
        Travel(direction);

        _lifetime -= Time.deltaTime;
        if (_lifetime <= 0) Destroy(gameObject);
    }
    #endregion
}