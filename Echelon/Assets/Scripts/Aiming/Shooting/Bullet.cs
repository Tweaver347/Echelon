using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToDestroy = 5f;
    public WeaponManager weapon;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        collisionSound soundComponent = collision.gameObject.GetComponent<collisionSound>();
        if (collision.gameObject.GetComponent<collisionSound>() != null)
        {
            soundComponent.playSound();
        }
        if (collision.gameObject.GetComponentInParent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponentInParent<EnemyHealth>();
            enemyHealth.takeDamage(weapon.damage);
        }
        Destroy(this.gameObject);

    }
}
