using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AudioClip _bullet_clip;
    public AudioSource _audio_Source;
    public int bullet_Count = 30;

    void OnTriggerEnter(Collider other)
    {
        Shooting.bulletCount += bullet_Count;
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        _audio_Source.PlayOneShot(_bullet_clip);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
