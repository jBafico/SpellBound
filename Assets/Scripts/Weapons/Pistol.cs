using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    [SerializeField] private SoundEffectController _soundEffect;
    [SerializeField] private GunStats _spell1;
    [SerializeField] private GunStats _spell2;
    
    private void Start()
    {
        EventsManager.Instance.OnSpellPickup += OnSpellPickup;
        _mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Reload();
        if (MageSpell.mageGunNumber == 0)
        {
            UpdateGunStats(_spell1);
        }
        else
        {
            UpdateGunStats(_spell2);
        }
    }
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

    private void OnSpellPickup()
    {
        MageSpell.mageGunNumber = 1;
        UpdateGunStats(_spell2);
    }
    
    
}
