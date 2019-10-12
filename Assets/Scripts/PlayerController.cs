using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 20;
    float jumpSpeed = 50;
    CharacterController Character;
    void Start()
    {
        Character = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 forwardAdjustment = speed*Input.GetAxis("Vertical") * transform.forward;
        Vector3 rightAdjustment = speed*Input.GetAxis("Horizontal") * transform.right;
        Vector3 move = forwardAdjustment + rightAdjustment;
        Character.Move(move*Time.deltaTime);

        Vector3 jump = jumpSpeed*Input.GetAxis("Jump") * transform.up;

    }
}
