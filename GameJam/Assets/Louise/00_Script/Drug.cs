using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Drug : Interactable
{
    public Volume volume;
    public VolumeProfile volumeProfile;
    public Rigidbody rigidbody;
    public Louise_Test louise_Test;
    void Start()
    {
        volume = FindObjectOfType<Volume>();
        rigidbody = GetComponent<Rigidbody>();
        louise_Test = FindObjectOfType<Louise_Test>();
        rigidbody.useGravity = false;
    }
    public override void Use()
    {
        base.Use();
        volume.sharedProfile = volumeProfile;
        louise_Test.timerEffect = 10f;
    }
}
