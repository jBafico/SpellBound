using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machingun : Gun
{
    [SerializeField] private int _shotCount = 5;
    public override void Attack()
    {
        if (CurrentBulletCount > 0)
        {
            Vector3 rotation = Input.mousePosition - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            for (int i = 0; i < _shotCount; i++)
            {
                GameObject bullet = Instantiate(
                    BulletPrefab,
                    transform.position + Vector3.forward * i * .6f,
                    Quaternion.Euler(0, 0, rotZ));
                //Seteamos el owner de la bala
                bullet.GetComponent<IBullet>().SetOwner(this);
                UpdateBulletCount();
            }
            
        }
    }

    public override void Reload() => base.Reload();
}
