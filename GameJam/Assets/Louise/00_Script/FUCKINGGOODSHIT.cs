using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FUCKINGGOODSHIT : Drug
{
    public AudioClip BRAINPOWER;
    public AudioSource source;

    public override void Use()
    {
        base.Use();
        volume.sharedProfile = volumeProfile;
        StartCoroutine(Recovery());
    }
    public virtual IEnumerator Recovery()
    {
        yield return new WaitForSeconds(10f);
        volume.sharedProfile = null;
    }
}
