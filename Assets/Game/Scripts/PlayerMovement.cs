using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] FloatingJoystick floatingJoystick;
    [SerializeField] float movementSpeed = 10f;

    private Rigidbody rb;

    private Vector3 direction;

    private float horizontalAxis;
    private float verticalAxis;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        horizontalAxis = floatingJoystick.Horizontal;
        verticalAxis = floatingJoystick.Vertical;

        direction = new Vector3(horizontalAxis, 0f, verticalAxis);
        direction = transform.TransformDirection(direction) * movementSpeed * Time.fixedDeltaTime;

        rb.MovePosition(transform.position + direction);
    }
}
