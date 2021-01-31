using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUCKINGGOODSHIT : Drug
{
    public AudioClip BRAINPOWER;
    public AudioSource[] audioSource;

    protected override void Start()
    {
        base.Start();
        audioSource = FindObjectsOfType<AudioSource>();
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].mute = true;
        }
    }

    public override void Use()
    {
        base.Use();
        volume.sharedProfile = volumeProfile;
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].mute = false;
        }
        meshRenderer.enabled = false;
        louise_Test.audioListener.enabled = true;
        StartCoroutine(Recovery());
    }
    public override IEnumerator Recovery()
    {
        yield return new WaitForSeconds(10f);
        volume.sharedProfile = onlyColorBlnd;
    }
}
