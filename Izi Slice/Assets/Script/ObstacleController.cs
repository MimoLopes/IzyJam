using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> sides;

    private Rigidbody rb;
    void Start()
    {
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Edge")
        {
            gameObject.SetActive(false);

            foreach (var side in sides)
            {
                side.SetActive(true);
                rb = side.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.one, ForceMode.Impulse);
            }
        }
    }

}
