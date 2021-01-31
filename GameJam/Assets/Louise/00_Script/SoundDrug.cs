using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundDrug : Drug
{
    public AudioSource audioSource;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();    
    }
    public override void Use()
    {
        audioSource.mute = false;
        Destroy(gameObject);
    }
}
