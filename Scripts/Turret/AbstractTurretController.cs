using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTurretController : MonoBehaviour {

    [SerializeField] protected float turnRate; //lag when the turret rotates. Different turrets should have different turnrates.
    protected const float baseTurnRate = 20;

    void Start () { 
        turnRate = baseTurnRate;
	}
		
    protected virtual void HandleTurret()
    {

    }

    protected virtual void SwapGun()
    {

    }
}
