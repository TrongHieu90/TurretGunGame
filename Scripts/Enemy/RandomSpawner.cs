using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : AbstractSpawner {

    private Vector3 _randloc;
    private float _randY; //random y location to spawn object
    [SerializeField] private int _amountToSpawn;

    [SerializeField] private float _countDownToNextSPawn = 5;
    [SerializeField] private float _countDownDuration;

     void Start () {
        if (_itemToSpawn.CompareTag("AirEnemy"))
        {
            _randY = 9.5f;
        }
        else
        {
            _randY = 1.53f;
        }
        _countDownDuration = _countDownToNextSPawn;
        Spawner();
    }

    private void Update()
    {
        if(gameObject.transform.childCount > 0 && gameObject.transform.childCount < _amountToSpawn)
        {
            
            _countDownToNextSPawn -= Time.deltaTime;
            if(_countDownToNextSPawn <= 0)
            {
                Spawn(1);
                _countDownToNextSPawn = _countDownDuration;
            }
        }
    }

    protected override void Spawn(int amountToSpawn)
    {  
        for (int i = 0; i < amountToSpawn; i++)
        {
            CreateRandomSpawnLoc();
            GameObject tempGO = (GameObject)Instantiate(_itemToSpawn, _randloc, _itemToSpawn.transform.rotation);

            tempGO.transform.SetParent(gameObject.transform);
       }      
    }

    private Vector3 CreateRandomSpawnLoc()
    {
        return _randloc = new Vector3(Random.Range(-60f, 60f), _randY, Random.Range(-60f, 60f));
    }

    private void Spawner()
    {
        if(gameObject.transform.childCount == 0)
        { 
            Spawn(_amountToSpawn);
        }
    }


}

