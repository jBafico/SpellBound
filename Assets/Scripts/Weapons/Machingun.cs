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
            for (int i = 0; i < _shotCount; i++)
            {
                GameObject bullet = Instantiate(
                    BulletPrefab,
                    transform.position + Vector3.forward * i * .6f,
                    Quaternion.identity);
                //Seteamos el owner de la bala
                bullet.GetComponent<IBullet>().SetOwner(this);
                UpdateBulletCount();
            }
            
        }
    }

    public override void Reload() => base.Reload();
}
