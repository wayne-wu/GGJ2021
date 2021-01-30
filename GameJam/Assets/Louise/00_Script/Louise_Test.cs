using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Louise_Test : MonoBehaviour
{
    public Transform volume;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        volume.position = transform.position;
    }
}
