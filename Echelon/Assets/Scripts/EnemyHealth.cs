using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip highHealthHitSound;
    public AudioClip lowHealthHitSound;

    public AudioClip deathSound;
    [SerializeField] private float health = 100;
    private float timeToDestroy = 5f;

    RagdollManager ragdollManager;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ragdollManager = GetComponent<RagdollManager>();
    }
    public void takeDamage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health > 50)
            {
                // play high health hit sound
                audioSource.PlayOneShot(highHealthHitSound);
            }
            else
            {
                // play low health hit sound
                audioSource.PlayOneShot(lowHealthHitSound);
            }
            if (health <= 0)
            {
                audioSource.PlayOneShot(deathSound);
                EnemyDeath();
            }
        }

    }

    void EnemyDeath()
    {
        Debug.Log("Enemy Dead");
        ragdollManager.TriggerRagdoll();
        Destroy(gameObject, timeToDestroy);
    }

}
