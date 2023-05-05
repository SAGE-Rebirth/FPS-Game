using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletRound;
    public float bulletSpeed;
    public float fireRate;

    bool shotFired;

    public void Shoot()
    {
        if (!shotFired)
        {
            var spawnBullet = GameObject.Instantiate(bulletRound, transform.position, transform.rotation);
            var rb = spawnBullet.GetComponent<Rigidbody>();

            rb.velocity = spawnBullet.transform.forward * bulletSpeed;

            Destroy(spawnBullet, 3f);

            shotFired = true;
            Invoke("ResetRound", fireRate);
        }
    }

    public void ResetRound()
    {
        shotFired = false;
    }
}
