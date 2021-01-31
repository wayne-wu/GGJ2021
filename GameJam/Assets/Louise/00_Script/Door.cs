using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : Interactable
{
    public Louise_Test louise;
    public bool isLock = true;

    public AsyncOperation async;
    void Start()
    {
        louise = FindObjectOfType<Louise_Test>();    
    }
    public override void Use()
    {
        if (isLock)
        {
            louise.centerUI.text = "門鎖住了我打不開";
            return;
        }
        else
        { 
            base.Use();

            async = SceneManager.LoadSceneAsync(1);
        }
    }
}
