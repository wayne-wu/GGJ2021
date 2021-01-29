using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    PlayerController playerController;

    void Start()
    {
        playerController = GetComponent<PlayerController>();    
    }
    void OnCollisionEnter(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
                {
                    playerController.grounded = true;
                    break;
                }

        }
    }
    void OnCollisionExit(Collision collision)
    {
        switch (collision.collider.tag)
        {
            case "Ground":
                {
                    playerController.grounded = false;
                    break;
                }

        }
    }
}
