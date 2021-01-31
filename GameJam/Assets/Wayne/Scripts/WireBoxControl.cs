using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireBoxControl : Interactable
{
    public bool isOpened = false;

    //private Vector3 OpenT = new Vector3(0.43f, 0f, 0.38f);
    private Quaternion OpenR = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);
    private Quaternion CloseR = new Quaternion(0f, 0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = isOpened ? OpenR : CloseR;
    }

    public override void Use()
    {
        if (isOpened)
        {
            return;
        }
        else
        {
            base.Use();
            transform.rotation = OpenR;
            isOpened = true;
            gameObject.layer = 0;
        }
    }

}
