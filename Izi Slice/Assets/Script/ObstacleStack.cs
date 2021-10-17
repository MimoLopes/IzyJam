using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleStack : MonoBehaviour
{
    [SerializeField]
    private GameObject obstacle;
    [SerializeField]
    private int numberOfObstacles;

    private Mesh mesh;
    private float size;
    private Vector3 position;

    void Start()
    {
        mesh = obstacle.GetComponentInChildren<MeshFilter>().sharedMesh;
        position = transform.position;

        for (int i = 0; i < numberOfObstacles; i++)
        {
            Instantiate(obstacle, position, Quaternion.identity);
            position.y += (mesh.bounds.size.y + 1f);
        }
    }
}
