using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Louise_Test : MonoBehaviour
{
    public Transform volumeTrans;
    public Volume volume;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //volume.sharedProfile
    }

    void Update()
    {
        volumeTrans.position = transform.position;
    }
}
