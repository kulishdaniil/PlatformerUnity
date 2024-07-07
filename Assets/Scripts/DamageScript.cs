using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float damageCount = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(FindObjectOfType<PlayerManagerHealth>().Damage(damageCount));
    }
}
