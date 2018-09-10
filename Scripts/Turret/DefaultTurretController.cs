using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DefaultTurretController : AbstractTurretController {

    [SerializeField] private Transform _turretTransform;
    [SerializeField] Reticle_Mouse_Input reticleScript;
    Vector3 _finalTurretLookDir;
    [SerializeField] private Transform _gunHolder;

    Dictionary<int, GameObject> _gunArsenal = new Dictionary<int, GameObject>();

    public event Action gunSwap;

    void Start ()
    {
        LoadUpGunArsenal();		
	}

	void Update () {
        HandleTurret();
        SwapGun();
	}

    protected override void HandleTurret()
    {
        if (_turretTransform)
        {
            Vector3 _turretLookDir = reticleScript.ReticlePos - _turretTransform.position;
            _turretLookDir.y = 0;         
            _finalTurretLookDir = Vector3.Lerp(_finalTurretLookDir, _turretLookDir, Time.deltaTime * turnRate);

            _turretTransform.rotation = Quaternion.LookRotation(_finalTurretLookDir);
        }
    }

    protected override void SwapGun()
    {               
        if(Input.anyKey)
        {
            //int parsing the keypress and check if our dictionary contains this key
            int _keyNumber;
            var _isInt = int.TryParse(Input.inputString, out _keyNumber);
            if (_isInt && _gunArsenal.ContainsKey(_keyNumber))
            {
                turnRate = baseTurnRate;
                foreach (GameObject item in _gunArsenal.Values)
                {
                    item.SetActive(false);
                }
                _gunArsenal[_keyNumber].SetActive(true);

                //Applying weight to our turret's turnrate
                turnRate -= _gunArsenal[_keyNumber].GetComponent<AbstractGun>().GunWeight;

                //fire gunswap Event
                if (gunSwap != null)
                {
                    gunSwap();
                }
            }
        }
    }

    private void LoadUpGunArsenal()
    {
        //load all the guns into our dictionary container.
        for(int i = 0; i < _gunHolder.childCount; i++)
        {
            _gunArsenal.Add(i+1, _gunHolder.GetChild(i).gameObject); //i + 1 so we can map keyboard '1' to 1st gun, keyboard '2' to 2nd gun and so forth.            
        }
    }
}
