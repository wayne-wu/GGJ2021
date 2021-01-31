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
    public bool buffDrug;
    //ColorBlind,CrawlingDrug

    void Start()
    {
        volume = FindObjectOfType<Volume>();
        louise_Test = FindObjectOfType<Louise_Test>();
    }
    public override void Use()
    {
        base.Use();
        if (louise_Test.effectWork)
        {
            return;
        }
        volume.sharedProfile = volumeProfile;
        louise_Test.effectWork = true;
        if (buffDrug)
        {
            Destroy(gameObject);
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
        volume.sharedProfile = null;
        louise_Test.effectWork = false;
    }
}
