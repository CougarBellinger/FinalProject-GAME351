using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController character;

    private float walkSpeed = 4f;
    private float runSpeed = 8f;

    private float sensitivity = 100f;

    public float groundCheckDistance = 20f;
    public LayerMask groundLayer;

    public bool isWalking = false;

    void Start()
    {
        character = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxisRaw("Mouse X");

        float speed;

        transform.Rotate(Vector3.up * mouseX);

        //Sprint
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        //Apply motion
        Vector3 move = transform.right * x + transform.forward * z;
        move = move.normalized * speed;
        character.Move(move * Time.deltaTime);

        //Determine bool of isWalking
        if (Mathf.Abs(character.velocity.magnitude) <= 0.001f)
        {
            isWalking = false;
        }
        else
        {
            isWalking = true;
        }

        RaycastHit hit;
        if (Physics.Raycast(character.transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y;
            transform.position = newPosition;
        }
    }


}
