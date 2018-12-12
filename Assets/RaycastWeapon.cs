using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : Weapon {

    public float range = 100;
    public GameObject hitEffect;
    public GameObject bulletTrail;
    protected override void LaunchProjectile()
    {
        base.LaunchProjectile();
        RaycastHit hit;

        GameObject trail = Instantiate(bulletTrail, bulletSpawn.position, Quaternion.identity);
        trail.transform.rotation = bulletSpawn.rotation;

        if (Physics.Raycast(bulletSpawn.position, bulletSpawn.forward, out hit, range))
        {
            Instantiate(hitEffect, hit.point, Quaternion.identity);
            float distance = Vector3.Distance(bulletSpawn.position, hit.point);
            trail.transform.localScale = new Vector3(1, 1, distance);
        }
        else
        {
            trail.transform.localScale = new Vector3(1, 1, range);
        }
    }
}
