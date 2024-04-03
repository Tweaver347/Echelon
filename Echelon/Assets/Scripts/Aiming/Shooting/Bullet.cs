using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeToDestroy = 5f;
    public WeaponManager weapon;
    public Vector3 dir;
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
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (collision.gameObject.GetComponentInParent<EnemyHealth>() != null)
        {
            enemyHealth.takeDamage(weapon.damage);
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(dir * weapon.enemyKickbackForce, ForceMode.Impulse);
        }
        Destroy(this.gameObject);

    }
}
