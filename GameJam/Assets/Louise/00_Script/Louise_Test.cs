using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Louise_Test : MonoBehaviour
{
    public Volume volume;
    public LayerMask interactable;
    public Text centerUI;
    public RaycastHit hit;
    public float timerEffect;
    public float touchDistence = 1;

    void Start()
    {
        volume = FindObjectOfType<Volume>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, touchDistence, interactable))
        {
            if (!centerUI.gameObject.activeSelf)
            {
                EnableCenterUI(hit.collider.GetComponent<Interactable>().type);
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponent<Interactable>().Use();
                //Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            if (centerUI.gameObject.activeSelf)
            {
                centerUI.gameObject.SetActive(false);
            }
        }
    }
    void EnableCenterUI(intercatableType type)
    {
        switch (type)
        {
            case intercatableType.Drug: centerUI.text = "按E食用"; 
                break;
            case intercatableType.Switch: centerUI.text = "按E切換開關";
                break;
            case intercatableType.Openthing: centerUI.text = "按E開啟";
                break;
        }
        centerUI.gameObject.SetActive(true);
    }
}
