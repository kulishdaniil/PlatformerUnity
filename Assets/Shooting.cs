using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float damage = 10;
    public float fireRate = 10;
    public float range = 15;
    public Transform bulletSpawn;
    public ParticleSystem muzzleFlash;
    public AudioClip shotSFX;
    public AudioSource _audioSource;

    public Camera _cam;
    private float nextFire = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        _audioSource.PlayOneShot(shotSFX);
        muzzleFlash.Play();
        
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range)) ;
        {
            Debug.Log("Ïèó ïèó");
        }
    }
}
