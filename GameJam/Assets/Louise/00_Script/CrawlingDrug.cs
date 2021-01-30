using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class CrawlingDrug : Interactable
{
    public FirstPersonController controller;
    public CharacterController characterController;
    void Start()
    {
        controller = FindObjectOfType<FirstPersonController>();
        characterController = controller.GetComponent<CharacterController>();

    }
    public override void Use()
    {
        base.Use();
        characterController.radius = 0f;
        characterController.height = 0.3f;
        controller.m_WalkSpeed = 0.5f;
        controller.m_RunSpeed = 0.5f;
        controller.isCrawling = true;
        StartCoroutine(Recovery());
    }

    public IEnumerator Recovery()
    {
        yield return new WaitForSeconds(10f);
        characterController.radius = 0.5f;
        characterController.height = 1.8f;
        controller.m_WalkSpeed = 2f;
        controller.m_RunSpeed = 5f;
        controller.isCrawling = false;
        Debug.Log("恢復");
    }
}
