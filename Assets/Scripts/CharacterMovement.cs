using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    private CharacterController character;
    public float movementSpeed = 1f;
    public float groundCheckDistance = 20f;
    public LayerMask groundLayer;
    private bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        isWalking = (Vector3.magnitude(move) == 0);

        if (isWalking && Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed *= 2f;
        }

        character.Move(move * Time.deltaTime * movementSpeed);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDistance, groundLayer))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y;
            transform.position = newPosition;
        }
    }
}
