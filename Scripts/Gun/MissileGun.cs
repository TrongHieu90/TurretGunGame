using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MissileGun : AbstractGun {

    private GameObject _tempBulletOb;

    protected override void Start () {
        base.Start();

        if (_bulletCount > 0)
        {
            CreateMissile();           
        }        
    }
	
	protected override void Update () {
        base.Update();
	}

    public override void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _tempBulletOb.GetComponent<SeekingMissile>()._seekingAllow = true;
            _tempBulletOb.transform.SetParent(null);         
            _bulletCount--;
            _tempBulletOb = null;         
        }
    }

    public override void Reload()
    {
        _reloadTimer -= Time.deltaTime;
        if (_reloadTimer <= 0)
        {
            _bulletCount = _localBulletCount;
            _canFire = true;
            _reloadTimer = _reloadDuration;
            CreateMissile();
        }
    }

    public override float DealDamage(float dmgAmount)
    {
        // adjust the dmg of each gun here with buff or debuff
        return _gunDmg;
    }

    private void CreateMissile()
    {
        _tempBulletOb = Instantiate(_bullet, _firePos.transform.position, _firePos.transform.rotation) as GameObject;
        _tempBulletOb.transform.SetParent(this.transform);
    }
}
