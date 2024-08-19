using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    //public Transform pistolTransform;
    public Transform cameraTransform;

    private Animator animator;
    private bool isMoving;

    private float rotationY = 0f;

    void Start()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("CameraTransform or PistolTransform is not assigned.");
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
        rotationY = transform.eulerAngles.y;
        //cameraTransform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        //cameraTransform.localRotation = Quaternion.Euler(cameraTransform.localEulerAngles.x, cameraTransform.localEulerAngles.y, 0f);

        animator = GetComponent<Animator>();
        //animator.Play("idle");
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection += transform.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection -= transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection -= transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }

        isMoving = moveDirection != Vector3.zero;

        if (isMoving)
        {
            animator.speed = 1f;
            moveDirection.Normalize();
            transform.position += moveDirection * movementSpeed * Time.deltaTime;
        }
        else
        {
            animator.speed = 0f;
        }
    }

    void HandleRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        rotationY += mouseX;
        transform.rotation = Quaternion.Euler(0f, rotationY, 0f);
        //cameraTransform.rotation = Quaternion.Euler(cameraTransform.localEulerAngles.x, rotationY, 0f);
    }
}
