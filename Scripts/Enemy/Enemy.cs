using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour, IDamageable<float>
{
    [SerializeField] protected float health;
    [SerializeField] AbstractGun _currentGun;
    protected float dmgTaken;
    [SerializeField] protected Slider _healthBar;
    [SerializeField] private float _enemyScore;

    void Start () {
        _currentGun = FindObjectOfType<AbstractGun>();
        //subcrible to gunSwap event
        FindObjectOfType<DefaultTurretController>().gunSwap += FindCurrentGunOnTurret;
        _healthBar.maxValue = health;
        _healthBar.wholeNumbers = true;
        _healthBar.value = health;

        if (gameObject.CompareTag("AirEnemy"))
        {
            _enemyScore = 20;
        }
        else
        {
            _enemyScore = 10;
        }
    }

    public void DamageTaken(float dmgTaken)
    {
        health -= dmgTaken;
        _healthBar.value = health;
    }

    protected void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            DamageTaken(_currentGun.GunDmg);
            CheckStatus();
        }
    }

    protected void CheckStatus()
    {
        if (health <= 0)
        {
            //unsubcribe from event
            FindObjectOfType<DefaultTurretController>().gunSwap -= FindCurrentGunOnTurret;

            //adding highscore
            GameplayManager.Instance._highScore += _enemyScore;

            Destroy(gameObject);
        }
    }

    protected void FindCurrentGunOnTurret()
    {
        _currentGun = FindObjectOfType<AbstractGun>();
    }
}
