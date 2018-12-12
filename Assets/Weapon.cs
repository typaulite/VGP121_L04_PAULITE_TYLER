using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public float fireRate = 10;
    public int magazineSize = 30;
    public float reloadTime = 1;
    public Transform bulletSpawn;

    private bool firing = false;
    private bool reloading = false;
    private int bulletsRemaining;
    private float timer = 0;

    //Audio
    public AudioSource src;
    public AudioClip fireSound;
    public AudioClip reloadSound;

	// Use this for initialization
	void Start () {
        bulletsRemaining = magazineSize;
        if (!GetComponent<AudioSource>())
        {
            gameObject.AddComponent<AudioSource>();
        }
        src = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (firing)
        {
            if (timer <= 0 && !reloading)
            {
                if(bulletsRemaining > 0)
                {
                    LaunchProjectile();
                    timer = 1 / fireRate;
                }
                else
                {
                    Reload();
                }
            }
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0;
        }
	}

    public void Fire(bool toggle)
    {
        firing = toggle;
    }

    protected virtual void LaunchProjectile()
    {
        bulletsRemaining--;
        src.PlayOneShot(fireSound);
    }

    private void Reload()
    {
        reloading = true;
        src.PlayOneShot(reloadSound);
        StartCoroutine("ReloadCoroutine");

    }

    IEnumerator ReloadCoroutine()
    {
        yield return new WaitForSeconds(reloadTime);
        bulletsRemaining = magazineSize;
        reloading = false;
        yield return null;
    }
}
