using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int damageCount = 10;

    private void OnCollisionEnter(Collision collision)
    {
        StartCoroutine(FindObjectOfType<PlayerManagerHealth>().Damage(damageCount));
    }
}
