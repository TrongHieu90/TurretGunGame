using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekingMissile : MonoBehaviour {

    [SerializeField] private GameObject _target;
    [SerializeField] MissileGun missile;
    [HideInInspector]public bool _seekingAllow;

    void Start () {
        missile = FindObjectOfType<MissileGun>();
        _target = GameObject.FindWithTag("AirEnemy");
        
	}

	void Update () {
        if(_seekingAllow)
        {
            if(_target)
            {
                HomingMissile();
            }
            else
            {
                Destroy(gameObject);
            }          
        }		
	}

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("AirEnemy"))
        {
            Destroy(gameObject);
        }
    }

    private void HomingMissile()
    {
        Vector3 _dir = _target.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(_dir);
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, missile.BulletSpeed * Time.deltaTime);
        Destroy(gameObject, 10);
    }
}
