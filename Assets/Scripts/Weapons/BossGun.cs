using UnityEngine;

public class BossGun : Gun
{
    #region GUN_PROPERTIES
    [SerializeField] private int _shotCount = 2;
    private int ticks = 500;
    #endregion

    #region I_GUN_METHODS

    private void Update()
    {
        _mousePos = _mainCam.ScreenToWorldPoint(GameObject.FindGameObjectWithTag("Player").gameObject.transform.position);
        Vector3 rotation = _mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation= Quaternion.Euler(0,0,rotZ);
        if (ticks == 0)
        {
            Attack();
            ticks = 500;
        }
        else
        {
            ticks--;
        }
    }

    public void Attack()
    {
        
            for (int i = 0; i < _shotCount; i++)
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
