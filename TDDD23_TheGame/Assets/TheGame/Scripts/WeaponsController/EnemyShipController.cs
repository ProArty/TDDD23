﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipController : BaseController
{
    // Start is called before the first frame update
    public GameObject Ship;
    public GameObject Target;  
    private float SpawnEvery = 1f;
    public bool Spawn = true;
    public float SpawnRange = 200f;
    void Start()
    {
        StartCoroutine(SpawnEnemyShips());
    }

    IEnumerator SpawnEnemyShips(){
        while(Spawn){
            GameObject ship = Instantiate(Ship, SpawnPosition(), Random.rotation);
            ship.GetComponent<ShipMovment>().Select(Target.transform);
            ship.transform.LookAt(LookPosition());
            yield return new WaitForSeconds(SpawnEvery);
            SpawnEvery *= 2;
        }
    }

    private Vector3 SpawnPosition(){
        return new Vector3(Random.Range(-300.0f, 300.0f), Random.Range(0.0f, 100.0f), SpawnRange);
    }
    private Vector3 LookPosition(){
        return new Vector3(Random.Range(-500.0f, 500.0f), Random.Range(-30.0f, 200.0f), 0);
    }
}
