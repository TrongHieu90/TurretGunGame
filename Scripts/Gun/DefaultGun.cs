using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGun : AbstractGun {

    [SerializeField] Reticle_Mouse_Input reticleScript;

    protected override void Start () {
        base.Start();
	}

    protected override void Update ()
    {
        base.Update();
	}

    public override void Fire()
    {
       if(Input.GetMouseButtonDown(0))
        {
            GameObject _tempBulletOb = Instantiate(_bullet, _firePos.transform.position, Quaternion.identity) as GameObject;
            Rigidbody _tempRb = _tempBulletOb.GetComponent<Rigidbody>();

            //Add force to bullet
            _tempRb.AddForce((reticleScript.ReticlePos - transform.position) * _bulletSpeed);
            _bulletCount--;

            Destroy(_tempBulletOb, 3.0f);
        }
    }

    public override float DealDamage(float dmgAmount)
    {
        // adjust the dmg of each gun here with buff or debuff
        return _gunDmg;
    }
}
