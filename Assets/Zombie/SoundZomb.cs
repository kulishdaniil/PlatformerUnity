using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundZomb : MonoBehaviour
{
    public Animator animator;
    public AudioSource _audioSource;
    public AudioClip idleSound;
    public AudioClip chasingSound;

    private int observerA=0, observerB=0;
    //public AudioClip attackSound;

/*    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }*/

    private void PlayLandingSound(AudioClip audio)
    {
        if (_audioSource.isPlaying)
        {
            if (observerB != observerA)
            {
                _audioSource.Stop();
                _audioSource.PlayOneShot(audio);
                observerB = observerA;
            }
        }
        else
        {
            _audioSource.PlayOneShot(audio);
        }
        
    }

    void Update()
    {
        if (animator.GetBool("isChasing") || animator.GetBool("isAttacking"))
        {
            observerA = 1;
            PlayLandingSound(chasingSound);
        }
        else
        {
            observerA = 0;
            PlayLandingSound(idleSound);
        }
    }
}
