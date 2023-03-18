using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float Speed = 5f;

    private Animator animator;

    // Only consider ground when aiming, otherwise funky behaviour occurs
    [SerializeField] private LayerMask groundMask;
    private Camera mainCamera;
    private Rigidbody rb;

    Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();

        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 cameraForward2DProjected = new Vector3(
            mainCamera.transform.forward.x,
            0,
            mainCamera.transform.forward.z
            ).normalized;
        Vector3 cameraRight = mainCamera.transform.right;

        moveDirection = (vInput * cameraForward2DProjected + hInput * cameraRight).normalized;


        bool isMoving = !moveDirection.Equals(new Vector3(0, 0, 0));
        animator.SetBool("IsMoving", isMoving);
    }

    private void FixedUpdate()
    {
        rb.velocity = moveDirection * Speed * Time.deltaTime;
    }
    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            var direction = position - transform.position;
            direction.y = 0;
            transform.forward = direction;
        }
    }

    // Translate pixel pos to pos in 3d space
    private (bool success, Vector3 position) GetMousePosition()
    {
        // Ray cast from camera to mouse pos to get position on ground surface
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }
}
