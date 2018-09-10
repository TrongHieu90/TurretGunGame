using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractGun : MonoBehaviour, IGun, IDamageDeal<float> {

    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected float _bulletSpeed;
    public float BulletSpeed { get { return _bulletSpeed; } }
    [SerializeField] protected float _bulletCount;
    public float BulletCount { get { return _bulletCount; } }
    protected float _localBulletCount;

    [SerializeField] protected float _gunDmg; 
    public float GunDmg { get { return _gunDmg; } } 
    
    [SerializeField] protected float _reloadTimer;
    public float ReloadTimer { get {return _reloadTimer; } }
    [SerializeField] protected float _reloadDuration;

    [SerializeField] protected Transform _firePos;

    protected bool _canFire;
    [SerializeField] protected float _gunWeight; //use this to adjust the turn rate of the turret. Heavy gun should have slower turnrate
    public float GunWeight { get { return _gunWeight; } }

    

    protected virtual void Start()
    {
        _reloadTimer = _reloadDuration;
        _canFire = true;
        _localBulletCount = _bulletCount;
    }

    protected virtual void Update()
    {
        if (_bullet && _canFire)
        {
            Fire();
        }
        CanFire();
        if (!_canFire)
        {
            Reload();
        }
    }

    public virtual float DealDamage(float dmgAmount)
    {
        return _gunDmg;
    }

    protected virtual bool CanFire()
    {
        if (_bulletCount <= 0)
        {
            _canFire = false;
        }
        return _canFire;
    }
    

    public virtual void Fire()
    {
        
    }

    public virtual void Reload()
    {       
        _reloadTimer -= Time.deltaTime;

        if (_reloadTimer <= 0 )
        {
            _bulletCount = _localBulletCount;
            _canFire = true;
            _reloadTimer = _reloadDuration;
        }
    }
}
