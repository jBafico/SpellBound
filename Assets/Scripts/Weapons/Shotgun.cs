using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Gun
{
    [SerializeField] private int _shotCount = 5;

    public override void Attack(Vector3 mousePos)
    {
        if (CurrentBulletCount > 0)
        {
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation= Quaternion.Euler(0,0,rotZ);
            for (int i = 0; i < _shotCount; i++)
            {
                GameObject bullet = Instantiate(
                    BulletPrefab,
                    transform.position + Random.insideUnitSphere * 1,
                    Quaternion.identity);
                //Seteamos el owner de la bala
                bullet.GetComponent<IBullet>().SetOwner(this);
                UpdateBulletCount();
            
            }
        }
        
    }

    public override void Reload() => base.Reload();
}
