using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MovementController : MonoBehaviour
{
    public CharacterController characterController;
    public Camera playerCamera;

    public float walkSpeed;
    public float runSpeed;
    public float defaultFOV;
    public float runFOV;

    private Vector3 moveDirection;
    private float moveSpeed;
    private float gravity = -9.81f;
    private Vector3 velocity;
    private float targetFOV;
    private float currentFOV;

    private movementStates movementState;
    private enum movementStates
    {
        walk,
        run
    }

    private void Start()
    {
        FixedHeight();
        targetFOV = defaultFOV;
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        moveDirection = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;

        HandleMovementStates();

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime + velocity * Time.deltaTime);

        UpdateFOV();
    }

    private void HandleMovementStates()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            SetMovementState(movementStates.run);
        }
        else
        {
            SetMovementState(movementStates.walk);
        }
    }
    
    private void SetMovementState(movementStates state)
    {
        movementState = state;

        if (movementState == movementStates.walk)
        {
            moveSpeed = walkSpeed;
            targetFOV = defaultFOV;
        }
        else if (movementState == movementStates.run)
        {
            moveSpeed = runSpeed;
            targetFOV = runFOV;
        }
    }

    private void UpdateFOV()
    {
        if (moveDirection != null)
        {
            currentFOV = Mathf.Lerp(currentFOV, targetFOV, 15f * Time.deltaTime);
            playerCamera.fieldOfView = currentFOV;
        }
    }

    private void FixedHeight()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + characterController.skinWidth, transform.position.z);
    }
}
