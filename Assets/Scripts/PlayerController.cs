using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    float speed = 20;
    float jumpSpeed = 50;
    CharacterController Character;
    private float gravSpeed = -20;
    private float gravity = 0;
    void Start()
    {
        Character = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 forwardAdjustment = speed*Input.GetAxis("Vertical") * transform.forward;
        Vector3 rightAdjustment = speed*Input.GetAxis("Horizontal") * transform.right;
        gravity += gravSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gravity = jumpSpeed;
        }
        Vector3 upAdjustment = gravity * transform.up;
        Vector3 move = forwardAdjustment + rightAdjustment + upAdjustment;

        Character.Move(move*Time.deltaTime);


       







    }
}
