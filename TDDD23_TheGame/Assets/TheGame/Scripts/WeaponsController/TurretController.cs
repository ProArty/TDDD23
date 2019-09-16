﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : BaseController
{
    public GameObject Turret;
    public GameObject ammo;  
    private List<GameObject> Turrets = new List<GameObject>();

    private int capacity = 300;
    private float force = 500;
    private float speed = 3f;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        Turrets.Add(Instantiate(Turret,  new Vector3(0.8f, 0.35f, 1.7f), Quaternion.identity));
        Turrets.Add(Instantiate(Turret,  new Vector3(0f, 0.25f, 4.1f), Quaternion.identity));
        Turrets.Add(Instantiate(Turret,  new Vector3(-0.8f, 0.35f, 1.7f), Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (selected != null){
            target();
            if (Input.GetMouseButtonDown(0)){
                int pos = Random.Range(0, Turrets.Count);

                GameObject gun = Turrets[counter].transform.Find("GunPos").gameObject;
                GameObject tip = gun.transform.Find("Tip").gameObject;

                GameObject bullet = Instantiate(ammo, tip.transform.position, new Quaternion(0,0,0,1));
                bullet.GetComponent<Bullet>().Select(selected);
                counter += 1;
                counter %= 3;
            }
        }

    }

    private void target(){
        foreach(GameObject turret in Turrets)
        {
            Vector3 relativePos = selected.position - turret.transform.position + selected.forward;
            Quaternion toRotation = Quaternion.FromToRotation(turret.transform.forward, relativePos);

            turret.transform.rotation = Quaternion.Lerp(turret.transform.rotation, toRotation, speed * Time.deltaTime);
            turret.transform.rotation = new Quaternion(0,turret.transform.rotation.y,0, 1);

            GameObject gun = turret.transform.Find("GunPos").gameObject;

            gun.transform.rotation = Quaternion.Lerp(gun.transform.rotation, toRotation, speed * Time.deltaTime);
            gun.transform.rotation = new Quaternion(gun.transform.rotation.x, turret.transform.rotation.y, 0, 1);

        }
    }

}
