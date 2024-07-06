using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    public Animator animator;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        StartCoroutine(Dead());
    }

    private IEnumerator Dead()
    {
        animator.SetTrigger("Dead");
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
