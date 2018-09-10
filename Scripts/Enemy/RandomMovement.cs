using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {


    [SerializeField] private float _movementSpeed = 10;
    [SerializeField] private Vector3 _randLoc;
    private Vector3 _finalDir;
    [SerializeField] private float turnRate = 15;


    // Use this for initialization
    void Start () {
        CreateRandLoc();
	}
	
	// Update is called once per frame
	void Update () {
        MoveToRandomLoc();
	}

    private void MoveToRandomLoc()
    {
        Vector3 _dir = _randLoc - transform.position;
        _finalDir = Vector3.Lerp(_finalDir, _dir, Time.deltaTime * turnRate);
        transform.rotation = Quaternion.LookRotation(_finalDir);
        transform.position = Vector3.MoveTowards(transform.position, _randLoc, _movementSpeed * Time.deltaTime);
        if(transform.position == _randLoc)
        {
            CreateRandLoc();
        }
    }

    private Vector3 CreateRandLoc()
    {
        _randLoc = new Vector3(Random.Range(-60f, 60f), transform.position.y, Random.Range(-60f, 60f)); //setting hard boundary for example only
        return _randLoc;
    }
}
