using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{

    public float speed;
    public BoidController flockDirection;
    // Start is called before the first frame update
    void Start()
    {
        speed += Random.Range(-3,3);
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position,20);
        Vector3 seperation = Vector3.zero;
        Vector3 cohesion = Vector3.zero;
        foreach(Collider c in colliders)
        {
            if (c.gameObject.GetComponent<Boids>() != null)
            {
                seperation += GetSeparationVector(c.transform);
                cohesion += c.transform.position;
            }
            else if (c.gameObject.GetComponent<PlayerController>() != null)
            {
                seperation += GetSeparationVector(c.transform);
            }
        }
        Vector3 Direction = flockDirection.Direction + seperation + cohesion;
        Quaternion boidRot = Quaternion.FromToRotation(Vector3.forward,Direction.normalized);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, boidRot.eulerAngles.y, 0),Time.deltaTime);
        transform.position += new Vector3(this.transform.forward.x,0,this.transform.forward.z) * (speed * Time.deltaTime);
        BoidController.atBounds(this, flockDirection);
    }

    Vector3 GetSeparationVector(Transform target)
    {
        var diff = transform.position - target.transform.position;
        var diffLen = diff.magnitude;
        var scaler = Mathf.Clamp01(1.0f - diffLen / 20);
        return diff * (scaler / diffLen);
    }
}
