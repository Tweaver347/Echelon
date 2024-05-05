using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class collisionSound : MonoBehaviour
{
    [SerializeField] AudioClip sound;
    AudioSource audioSource;
    [SerializeField] LayerMask collisionLayer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        audioSource.PlayOneShot(sound);
    }


}
