using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float upForce;
    [SerializeField]
    private float sideForce;
    [SerializeField]
    private float torqueForce;

    private Rigidbody rb;
    private float gravity = 4f;
    private float groundedGravity = 0.05f;

    private bool isGrounded;
    public bool IsGounded
    {
        set
        {
            isGrounded = value;
        }
    }

    private bool canBeGrounded;
    public bool CanBeGrounded
    {
        get
        {
            return canBeGrounded;
        }
        set
        {
            canBeGrounded = value;
        }
    }
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        ModifyRotate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(ref isGrounded);
        }

        ImproveGravity(isGrounded, groundedGravity, gravity);
    }

    private void Jump(ref bool state)
    {
        if (isGrounded)
        {
            state = false;
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        rb.velocity = new Vector3(sideForce, upForce, 0f);

        rb.AddRelativeTorque(Vector3.forward * -torqueForce, ForceMode.Acceleration);
    }

    private void ModifyRotate()
    {
        if (transform.eulerAngles.z <= 360f && transform.eulerAngles.z >= 315f)
        {
            rb.angularDrag = 2.5f;
        }
        else if (transform.eulerAngles.z >= 0f && transform.eulerAngles.z <= 50f)
        {
            rb.angularDrag = 5.5f;
        }
        else
        {
            rb.angularDrag = 0.05f;
        }
    }

    private void ImproveGravity(bool state, float forceZero, float forceOne)
    { 
        if(state)
        {
            rb.isKinematic = true;
            rb.AddForce(Vector3.down * forceZero, ForceMode.Force);
        }
        else
        {
            rb.isKinematic = false;
            rb.AddForce(Vector3.down * forceOne, ForceMode.Force);
        }
    }
}
