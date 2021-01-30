using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Drug : Interactable
{
    public Volume volume;
    public VolumeProfile volumeProfile;
    public Louise_Test louise_Test;
    void Start()
    {
        volume = FindObjectOfType<Volume>();
        louise_Test = FindObjectOfType<Louise_Test>();
    }
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
