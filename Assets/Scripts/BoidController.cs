using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidController : MonoBehaviour
{
    public Vector3 Direction;

    public Vector3 start = Vector3.forward*300;
    public Vector3 end = Vector3.back*300;

    private void Update()
    {

    }
    public static void atBounds(Boids boid, BoidController boidController)
    {
        if (boidController.end.z > boid.transform.position.z)
        {
            boid.transform.position = new Vector3(boid.transform.position.x,boid.transform.position.y,boidController.start.z);
        }
        if (boidController.start.z < boid.transform.position.z)
        {
            boid.transform.position = new Vector3(boid.transform.position.x, boid.transform.position.y, boidController.end.z);
        }
    }
}
