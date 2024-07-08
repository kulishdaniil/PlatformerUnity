using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public AudioClip _health_clip;
    public AudioSource _audio_Source;
    public int Health_Count = 20;

    void OnTriggerEnter(Collider other)
    {
        PlayerManagerHealth.playerHealth += Health_Count;
        if (PlayerManagerHealth.playerHealth > PlayerManagerHealth.maxHealth)
        {
            PlayerManagerHealth.playerHealth = PlayerManagerHealth.maxHealth;
        }
        StartCoroutine(Play());
    }

    private IEnumerator Play()
    {
        _audio_Source.PlayOneShot(_health_clip);
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
