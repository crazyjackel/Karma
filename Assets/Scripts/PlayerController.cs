using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    public float jumpSpeed = 50;
    private CharacterController Character;
    public float gravSpeed = -20;
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
        //Determines fall time
        gravity += gravSpeed * Time.deltaTime;

        //Sets the gravity to the jump speed if the user preseses spacebar
        if (Input.GetKeyDown(KeyCode.Space)&&Character.isGrounded)
        {
            gravity = jumpSpeed;
        }
        //Makes the user go up if their gravity is positive
        Vector3 upAdjustment = gravity * transform.up;

        //Enables movement as a result of the following attributes
        Vector3 move = forwardAdjustment + rightAdjustment + upAdjustment;
        Character.Move(move*Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, DataManager.INSTANCE.MainPlayerCamera.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.gameObject.GetComponent<InteractableObject>()!=null)
                {
                    GameObject computer = hit.collider.gameObject;
                    MeshRenderer compMesh = computer.GetComponent<MeshRenderer>();
                    Material m = compMesh.materials[1];
                    m.color = Color.white;
                    m.mainTexture = DataManager.INSTANCE.pic.pic;
                }
            }
        }
    }
}
