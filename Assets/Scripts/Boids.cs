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
        Vector3 avoidDirection = Vector3.zero;
        foreach(Collider c in colliders)
        {
            if(c.gameObject.GetComponent<Boids>() != null)
            {
                Vector3 dif = (this.transform.position-c.transform.position);
                dif = dif / (1+dif.magnitude * dif.magnitude);
                avoidDirection += dif;
            }
            if(c.gameObject.GetComponent<PlayerController>()!= null)
            {
                Vector3 dif = (this.transform.position - c.transform.position);
                dif = dif / (1+dif.magnitude * dif.magnitude);
                avoidDirection += 10*dif;
            }
        }
        avoidDirection = avoidDirection.normalized + flockDirection.Direction;
        avoidDirection = avoidDirection.normalized;
        avoidDirection = new Vector3(avoidDirection.x, 0, avoidDirection.z);
        transform.position += avoidDirection * Time.deltaTime*speed;

        BoidController.atBounds(this, flockDirection);
    }
}
