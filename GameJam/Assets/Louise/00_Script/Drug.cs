using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody),typeof(BoxCollider))]
public class Drug : Interactable
{
    protected Volume volume;
    public VolumeProfile volumeProfile;
    protected Louise_Test louise_Test;
    public VolumeProfile onlyColorBlnd;
    public bool buffDrug;
    public MeshRenderer meshRenderer;
    //ColorBlind,CrawlingDrug

    protected virtual void Start()
    {
        volume = FindObjectOfType<Volume>();
        louise_Test = FindObjectOfType<Louise_Test>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
    public override void Use()
    {
        if (louise_Test.effectWork)
        {
            return;
        }
        base.Use();
        volume.sharedProfile = volumeProfile;
        louise_Test.effectWork = true;
        if (buffDrug)
        {
            meshRenderer.enabled = false;
            louise_Test.effectWork = false;
        }
        else
        { 
            StartCoroutine(Recovery());
        }
    }
    public virtual IEnumerator Recovery()
    {
        yield return new WaitForSeconds(10f);
        volume.sharedProfile = onlyColorBlnd;
        louise_Test.effectWork = false;
    }
}
