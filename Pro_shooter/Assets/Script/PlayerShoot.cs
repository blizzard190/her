using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject cube;

    public Transform bulletSpawn;

    public void Shoot()
    {
        var bullet = (GameObject)Instantiate(cube, bulletSpawn.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        Destroy(bullet, 2.0f);
    }
}
