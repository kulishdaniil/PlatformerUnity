using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    public float damage = 10;
    public float fireRate = 5;
    public float range = 30;
    public static int bulletCount;
    public int StartbulletCount = 100;
    public Transform bulletSpawn;
    public ParticleSystem muzzleFlash;
    public TextMeshProUGUI playerBulletText;

    public GameObject impactEffect;
    public GameObject HpEffect;

    public AudioClip shotSFX;
    public AudioSource _audioSource;

    public Camera _cam;
    private float nextFire = 0;

    void Start()
    {
        bulletCount = StartbulletCount;
    }


    void Update()
    {
        playerBulletText.text = "" + bulletCount;
        if (Input.GetButton("Fire1") && Time.time > nextFire && bulletCount > 0)
        {
            nextFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        _audioSource.PlayOneShot(shotSFX);
        muzzleFlash.Play();
        bulletCount-- ;
        
        RaycastHit hit;

        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject HP = Instantiate(HpEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(HP, 1f);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 1f);
        }
    }
}
