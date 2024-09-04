using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public override void Attack()
    {
        if (CurrentBulletCount > 0)
        {
            GameObject bullet = Instantiate(
                BulletPrefab, 
                transform.position, 
                transform.rotation);
            //Seteamos el owner de la bala
            bullet.GetComponent<IBullet>().SetOwner(this);
            UpdateBulletCount();
        }
        
    }

    public override void Reload() => base.Reload();
}
