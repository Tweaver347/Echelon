using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIWeaponScript : MonoBehaviour
{
    [SerializeField] AudioClip fireSound;
    public AudioSource audioSource;
    public Light muzzleFlashLight;
    public ParticleSystem muzzleFlash;
    public float lightIntensity;
    public float lightReturnSpeed = 1;

 void Start()
    {
        audioSource = GetComponent<AudioSource>();
        muzzleFlashLight = GetComponentInChildren<Light>();
        lightIntensity = muzzleFlashLight.intensity;
        muzzleFlashLight.intensity = 0;
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }

    public void playParticleSystem(){
        // play audio
        audioSource.PlayOneShot(fireSound);
        // trigger VFX
        TriggerMuzzleFlash();
        // lerp light intensity
        muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, lightReturnSpeed * Time.deltaTime);

    }

    void TriggerMuzzleFlash()
    {
        muzzleFlash.Play();
        muzzleFlashLight.intensity = lightIntensity;
    }
}
