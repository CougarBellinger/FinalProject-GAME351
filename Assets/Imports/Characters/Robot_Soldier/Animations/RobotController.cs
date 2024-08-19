using UnityEngine;

public class RobotController : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float mouseSensitivity = 2f;
    public Transform cameraTransform;
    public LayerMask terrainLayer; // 用于定义地形的层

    private Animator animator;
    private bool isMoving;

    private float rotationY = 0f;

    void Start()
    {
        if (cameraTransform == null)
        {
            Debug.LogError("CameraTransform is not assigned.");
            return;
        }
        Cursor.lockState = CursorLockMode.Locked;
        rotationY = transform.eulerAngles.y;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        FollowTerrain();
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
    }

    void FollowTerrain()
    {
        Ray ray = new Ray(transform.position + Vector3.up, Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayer))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = hit.point.y;
            transform.position = newPosition;
        }
    }
}
