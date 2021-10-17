using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeController : MonoBehaviour
{
    PlayerController controller;

    void Start()
    {
        controller = gameObject.GetComponentInParent<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ground" && controller.CanBeGrounded)
        {
            controller.IsGounded = true;
            controller.CanBeGrounded = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Ground" && !controller.CanBeGrounded)
        {
            controller.IsGounded = false;
            controller.CanBeGrounded = true;
        }
    }
}
