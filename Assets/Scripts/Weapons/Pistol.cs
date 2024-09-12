using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public override void Attack()
    {
        if (CurrentBulletCount > 0)
        {
            Vector3 rotation = Input.mousePosition - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            GameObject bullet = Instantiate(
                BulletPrefab, 
                transform.position, 
                Quaternion.Euler(0, 0, rotZ));
            //Seteamos el owner de la bala
            bullet.GetComponent<IBullet>().SetOwner(this);
            UpdateBulletCount();
        }
        
    }

    public override void Reload() => base.Reload();
}
