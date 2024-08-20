using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController character;
    public float movementSpeed = 1f;
    public float sensitivity = 100f;
    public float groundCheckDistance = 20f;
    public LayerMask groundLayer;
    public bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        character.Move(move * Time.deltaTime * movementSpeed);

        if (character.velocity != Vector3.zero)
        {
            isWalking = true;
        }

        else
        {
            isWalking = false;
        }
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y;
            transform.position = newPosition;
        }
    }
}
