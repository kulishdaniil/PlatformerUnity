using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip _bullet_clip;
    public AudioSource _audio_Source;

    void OnTriggerEnter(Collider other)
    {
        _audio_Source.PlayOneShot(_bullet_clip);
        Destroy(gameObject);
        Shooting.bulletCount += 10;
    }
}
