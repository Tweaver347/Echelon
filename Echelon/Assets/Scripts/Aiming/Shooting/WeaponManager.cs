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
    public float damage = 20;
    AimManager aim;

    // Sound
    [SerializeField] AudioClip fireSound;
    AudioSource audioSource;

    // Ammo
    WeaponAmmo ammo;
    WeaponBloom bloom;
    ActionStateManager actions;

    WeaponRecoil recoil;
    Light muzzleFlashLight;
    ParticleSystem muzzleFlash;
    float lightIntensity;
    float lightReturnSpeed = 1;

    public float enemyKickbackForce = 100;

    void Start()
    {
        bloom = GetComponent<WeaponBloom>();
        recoil = GetComponent<WeaponRecoil>();
        ammo = GetComponent<WeaponAmmo>();
        audioSource = GetComponent<AudioSource>();
        aim = GetComponentInParent<AimManager>();
        actions = GetComponentInParent<ActionStateManager>();
        muzzleFlashLight = GetComponentInChildren<Light>();
        lightIntensity = muzzleFlashLight.intensity;
        muzzleFlashLight.intensity = 0;
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
        fireRateTimer = fireRate;
    }

    void Update()
    {
        if (ShouldFire())
            Fire();
        muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, lightReturnSpeed * Time.deltaTime);
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
        barrelPos.localEulerAngles = bloom.bloomAngle(barrelPos);
        audioSource.PlayOneShot(fireSound);
        recoil.triggerRecoil();
        TriggerMuzzleFlash();
        ammo.currentAmmo -= bulletsPerShot;
        for (int i = 0; i < bulletsPerShot; i++)
        {
            GameObject currbullet = Instantiate(bulletPrefab, barrelPos.position, barrelPos.rotation);

            Bullet bulletScript = currbullet.GetComponent<Bullet>();
            bulletScript.weapon = this;

            bulletScript.dir = barrelPos.transform.forward;

            Rigidbody rb = currbullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);

        }
    }

    void TriggerMuzzleFlash()
    {
        muzzleFlash.Play();
        muzzleFlashLight.intensity = lightIntensity;
    }
}