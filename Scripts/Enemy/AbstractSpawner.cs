using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractSpawner : MonoBehaviour {

    [SerializeField] protected GameObject _itemToSpawn;


    protected abstract void Spawn(int amountToSpawn);
}
