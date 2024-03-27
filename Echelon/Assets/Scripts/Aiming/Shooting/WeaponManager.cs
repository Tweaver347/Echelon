using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    // Fire Rate
    [SerializeField] float fireRate = 0.1f;
    float fireRateTimer;
    [SerializeField] bool semiAuto;

    // Bullet Properties
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletsPerShot;
    AimManager aim;

    // Sound
    [SerializeField] AudioClip fireSound;
    AudioSource audioSource;

    // Ammo
    WeaponAmmo ammo;
    ActionStateManager actions;


    void Start()
    {
        ammo = GetComponent<WeaponAmmo>();
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<AimManager>();
        actions = GetComponentInParent<ActionStateManager>();
        fireRateTimer = fireRate;
    }

    void Update()
    {
        if (ShouldFire())
            Fire();
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;

        if (fireRateTimer < fireRate)
            return false;
        if (ammo.currentAmmo == 0)
            return false;
        if (actions.currentState == actions.Reload)
            return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0))
            return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0))
            return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        barrelPos.LookAt(aim.aimPos);
        audioSource.PlayOneShot(fireSound);
        ammo.currentAmmo -= bulletsPerShot;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currbullet = Instantiate(bulletPrefab, barrelPos.position, barrelPos.rotation);
            Rigidbody rb = currbullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);

        }
    }
}