using Unity.VisualScripting;
using UnityEngine;

public class BossGun : Gun
{
    #region PROPERTIES
    private float _currentTimer;  
    [SerializeField] public float fireRate = 1.0f; 
    #endregion

    #region I_GUN_METHODS

    private void Update()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        _currentTimer -= Time.deltaTime;
        if (_currentTimer <= 0f)
        {
            Attack();
            _currentTimer = fireRate; 
        }
    }

    public void Attack()
    {
        for (int i = 0; i < GunStats.ShotCount; i++)
        {
            GameObject bullet = Instantiate(
                BulletPrefab,
                transform.position + Vector3.forward * i * 0.6f,
                Quaternion.identity);

            // Set the owner of the bullet
            bullet.GetComponent<IBullet>().SetOwner(this);
        }
    }

    #endregion
}
