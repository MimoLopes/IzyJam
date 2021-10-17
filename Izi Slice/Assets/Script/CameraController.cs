using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private Vector3 offset;

    void Start()
    {
        
    }

    void Update()
    {
        if (target)
        {
            transform.position = target.transform.localPosition + offset;
            transform.LookAt(target.transform.localPosition);
        }
    }
}
