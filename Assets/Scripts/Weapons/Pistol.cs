using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    [SerializeField] private SoundEffectController _soundEffect;
    public override void Attack()
    {
        if (CurrentBulletCount > 0)
        {
            GameObject bullet = Instantiate(
                BulletPrefab, 
                transform.position, 
                Quaternion.identity);
            //Seteamos el owner de la bala
            bullet.GetComponent<IBullet>().SetOwner(this);
            _soundEffect.Play();
            UpdateBulletCount();
            EventsManager.Instance.EventManaUpdate(CurrentBulletCount);
        }
        
    }

    public override void Reload() {
        base.Reload();
        EventsManager.Instance.EventManaUpdate(CurrentBulletCount);
    }
}
