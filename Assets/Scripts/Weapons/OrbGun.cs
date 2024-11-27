using Unity.VisualScripting;
using UnityEngine;

public class OrbGun : Gun
{
    
    #region I_GUN_METHODS

    private void Update()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0,0,rotZ);
        if (_currentTicks == 0)
        {
            Attack();
            _currentTicks = ticks;
        }
        else
        {
            _currentTicks--;
        }
    }

    public void Attack()
    {
        
        for (int i = 0; i < GunStats.ShotCount ; i++)
        {
            GameObject bullet = Instantiate(
                BulletPrefab,
                transform.position + Vector3.forward * i * .6f,
                Quaternion.identity);
            //Seteamos el owner de la bala
            bullet.GetComponent<IBullet>().SetOwner(this);
                
        }
        
    }

    
    
    #endregion
}