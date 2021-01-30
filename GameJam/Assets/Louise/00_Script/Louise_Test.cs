using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Louise_Test : MonoBehaviour
{
    public Volume volume;
    //public VolumeProfile[] volumeProfiles;
    public VolumeProfile volumeProfile;
    public Transform volumeTrans;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        volume = FindObjectOfType<Volume>();
        volumeTrans = volume.GetComponent<Transform>();
        //volume.sharedProfile
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            volumeTrans.position = transform.position;
        }
        else if(Input.GetKeyDown(KeyCode.K))
        { 
            volume.sharedProfile = volumeProfile;
        }
    }
}
