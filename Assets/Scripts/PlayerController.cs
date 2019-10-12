using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 200;
    CharacterController Character;
    void Start()
    {
        Character = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 forwardAdjustment = speed*Input.GetAxis("Vertical") * DataManager.INSTANCE.MainPlayerCamera.transform.forward;
        Vector3 RightAdjustment = speed*Input.GetAxis("Horizontal") * transform.right;
        Vector3 move = forwardAdjustment + RightAdjustment;
        Character.SimpleMove(move*Time.deltaTime);

    }
}
