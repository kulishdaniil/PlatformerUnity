using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundRhino : MonoBehaviour
{
    public Animator animator;
    public AudioSource _audioSource;
    public AudioClip attackingSound;
    public AudioClip shoutingSound;
    public AudioClip chasingSound;

    private int observerA = 0, observerB = 0;

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
            if(observerB!=2 && observerA!=2)_audioSource.PlayOneShot(audio);
        }
    }

    void Update()
    {
        if (animator.GetBool("isChasing"))
        {
            observerA = 1;
            PlayLandingSound(chasingSound);
        }
        else
        {
            if (animator.GetBool("isAttacking"))
            {
                observerA = 0;
                PlayLandingSound(attackingSound);
            }
            else
            {
                if (animator.GetBool("isShoutSound"))
                {
                    observerA = 2;
                    PlayLandingSound(shoutingSound);
                }
            }
        }

    }
}
