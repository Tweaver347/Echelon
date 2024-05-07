using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip backgroundMusicClip;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true;
        audioSource.Play();
    }
}