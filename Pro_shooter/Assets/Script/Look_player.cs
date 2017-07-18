using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look_player : MonoBehaviour {
    public Transform Player;
    public float fireRate = 0.5F;
    public float nextFire = 0.0F;
    public GameObject cube;
    public Transform bulletSpawn;

    public void Shoot()
    {
        var bullet = (GameObject)Instantiate(cube, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;
    }

    void Update()
         {

            if (Player != null)
            {
                transform.LookAt(Player);
            }
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Shoot();
            }
       }
    }
